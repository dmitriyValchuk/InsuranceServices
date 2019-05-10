using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using InsuranceServices.Models;
using Newtonsoft.Json;

namespace InsuranceServices.Controllers
{
    public class ConditionsController : Controller
    {
        InsuranceServicesContext db = new InsuranceServicesContext();

        enum ResponseType
        {
            Bad,
            Critical,
            Good
        }

        class ResponseToClient
        {
            public ResponseType responseType { get; set; }
            public string responseText { get; set; }
        }

        public string GetRegions()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<string> regioneOfRegistration = db.RegioneOfRegistration.Select(region => region.Name).ToList();
            regioneOfRegistration.Sort();
            return js.Serialize(regioneOfRegistration);
        }

        public string GetCities(string regionName)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            int idRegioneOfRegistration = db.RegioneOfRegistration.Where(r => r.Name == regionName).Select(r => r.Id).First();

            List<string> cityOfRegistration = db.CityOfRegistration
                                                .Where(c => c.IdRegioneOfRegistration == idRegioneOfRegistration)
                                                .Select(c => c.Name)
                                                .ToList();
            cityOfRegistration.Sort();
            return js.Serialize(cityOfRegistration);
        }

        public string GetCodesTSC()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var TSC = db.TSC
                        .OrderBy(tsc => tsc.Code)
                        .ToList();
            List<TSCToSend> TSCToSends = new List<TSCToSend>();

            foreach (var tsc in TSC)
            {
                TSCToSend currentTSCToSend = new TSCToSend();
                currentTSCToSend.codeNum = tsc.Code;
                currentTSCToSend.cityName = tsc.CityOfRegistration.Name;
                currentTSCToSend.regionName = tsc.CityOfRegistration.RegioneOfRegistration.Name;

                TSCToSends.Add(currentTSCToSend);
            }
 
            return js.Serialize(TSCToSends);
        }

        public string GetCountries()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            List<string> countries = db.CountryOfRegistration.Select(c => c.Name).ToList();
            countries.Sort();

            return js.Serialize(countries);
        }

        [HttpPost]
        public string SendConditions()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ResponseToClient responseToClient = new ResponseToClient();
            List<ResponseToClient> warnings = new List<ResponseToClient>();

            string defaultErrorMessage = "Будь ласка скористайтеся сервісом пізніше. Дякуємо за розуміння.";
            string defaultConfigMessage = "За замовчанням встановлено";

            dynamic dataParsed = GetPotsRequestBody();
            if(dataParsed == null)
            {
                responseToClient.responseType = ResponseType.Critical;
                responseToClient.responseText = "Виникла помилка з обробкою Ваших даних. " + defaultErrorMessage;
                return js.Serialize(responseToClient);
            }           

            ConditionsForDocument conditionsForDocument = new ConditionsForDocument();

            if(dataParsed.trans.type == null || dataParsed.trans.extra == null)
            {
                responseToClient.responseType = ResponseType.Critical;
                responseToClient.responseText = "Виникла помилка при обробці даних. " + defaultErrorMessage;
                return js.Serialize(responseToClient);
            }
            string currentTransportType = dataParsed.trans.type;
            string currentInsurenceType = dataParsed.trans.extra;

            //var a = db.CarGlobalType.Where(c => c.Name == currentTransportType).First();
            //var b = db.CarInsuranceType.Where(c => c.Type == currentInsurenceType).First();
            Transport transport = new Transport();
            CarGlobalType currentType = new CarGlobalType();
            CarInsuranceType currentSubType = new CarInsuranceType();
            currentType = db.CarGlobalType.Where(c => c.Name == currentTransportType).First();
            currentSubType = db.CarInsuranceType.Where(c => c.Type == currentInsurenceType).First();

            transport.Type = currentType;
            transport.SubType = currentSubType;

            conditionsForDocument.Transport = transport;
            
            if(conditionsForDocument.Transport.Type == null || conditionsForDocument.Transport.SubType == null)
            {
                responseToClient.responseType = ResponseType.Critical;
                responseToClient.responseText = "Не корректні дані для типу автомобіля.";
                return js.Serialize(responseToClient);
            }

            PlaceOfRegistration placeOfRegistration = new PlaceOfRegistration();
            CityOfRegistration cityOfRegistration = new CityOfRegistration();
            CountryOfRegistration countryOfRegistration = new CountryOfRegistration();

            GetPlaceOfRegistration(dataParsed, ref cityOfRegistration, ref countryOfRegistration);

            placeOfRegistration.CityOfRegistration = cityOfRegistration;
            placeOfRegistration.CountryOfRegistration = countryOfRegistration;

            conditionsForDocument.PlaceOfRegistration = placeOfRegistration;
            
            if(placeOfRegistration.CityOfRegistration == null && placeOfRegistration.CountryOfRegistration == null)
            {
                responseToClient.responseType = ResponseType.Critical;
                responseToClient.responseText = "Виникла проблема з місцем реєстрації Вашого авто. Будь ласка поверніться на попередню сторінку та змініть місце реєстрації автомобіля";
                return js.Serialize(responseToClient);
            }

            bool isLegalEntity;
            bool parseIsLegalEntityResult = bool.TryParse(dataParsed.isLegalEntity.ToString(), out isLegalEntity);
            if (!parseIsLegalEntityResult)
            {
                isLegalEntity = false;
                responseToClient.responseType = ResponseType.Bad;
                responseToClient.responseText = "Не вдалося отримати дані по юридичній або фізичнії особі. " + defaultConfigMessage + " \"Фізична особа\".";
                warnings.Add(responseToClient);
            }
            conditionsForDocument.IsLegalEntity = isLegalEntity;

            PeriodOfDocument periodOfDocument = new PeriodOfDocument();
            double currentPeriod;
            bool parsePeriodResult = double.TryParse(dataParsed.period.term.ToString(), out currentPeriod);
            if (!parsePeriodResult)
            {
                currentPeriod = 12.0;
                responseToClient.responseType = ResponseType.Bad;
                responseToClient.responseText = "Не вдалося отримати дані по періоду страхування. " + defaultConfigMessage + " \"12 місяців\".";
                warnings.Add(responseToClient);
            }
            periodOfDocument.Period = currentPeriod;

            bool isMTC;
            bool parseIsMTCResult = bool.TryParse(dataParsed.period.otk.ToString(), out isMTC);
            if (!parseIsMTCResult)
            {
                isMTC = false;
                responseToClient.responseType = ResponseType.Bad;
                responseToClient.responseText = "Не вдалося отримати дані про необхідності проходження обов'язкового технічного контролю. " + defaultConfigMessage + " \"Не проходить\".";
                warnings.Add(responseToClient);
            }
            periodOfDocument.isMTC = isMTC;
            conditionsForDocument.PeriodOfDocument = periodOfDocument;

            bool isUseAsTaxi;
            bool parseIsTaxiCarResult = bool.TryParse(dataParsed.taxi.ToString(), out isUseAsTaxi);
            if (!parseIsTaxiCarResult)
            {
                isUseAsTaxi = false;
                responseToClient.responseType = ResponseType.Bad;
                responseToClient.responseText = "Не вдалося з'ясувати чи використовується Ваше авто в таксі. " + defaultConfigMessage + " \"Не використовується\".";
                warnings.Add(responseToClient);
            }
            conditionsForDocument.IsUseAsTaxi = isUseAsTaxi;


            DriverAccident driverAccident = new DriverAccident();
            bool isDriverWasInAccident;
            bool parseIsDriverWasInAccident = bool.TryParse(dataParsed.dtp.dtpState.ToString(), out isDriverWasInAccident);
            if (!parseIsDriverWasInAccident)
            {
                isDriverWasInAccident = false;
                responseToClient.responseType = ResponseType.Bad;
                responseToClient.responseText = "Не вдалося отримати дані про наявність страхових випадків. " + defaultConfigMessage + " \"Не було\".";
                warnings.Add(responseToClient);
            }
            if (isDriverWasInAccident)
            {
                int currentLastAccidentYear;
                bool parseLastAccidentYear = Int32.TryParse(dataParsed.dtp.dtpTerm.ToString(), out currentLastAccidentYear);
                if (!parseLastAccidentYear)
                {
                    currentLastAccidentYear = 4;
                    responseToClient.responseType = ResponseType.Bad;
                    responseToClient.responseText = "Не вдалося отримати дані про час останнього страхового випадку. " + defaultConfigMessage + " \"Не було\".";
                    warnings.Add(responseToClient);
                }
                //for 4 year and more, coef is same
                driverAccident.IsDriverWasInAccident = isDriverWasInAccident;
                driverAccident.LastAccidentYear = currentLastAccidentYear;
            }
            else
            {
                driverAccident.IsDriverWasInAccident = isDriverWasInAccident;
                driverAccident.LastAccidentYear = 4;
            }

            conditionsForDocument.DriverAccident = driverAccident;

            bool isClientHasPrivilegs;
            bool parseIsClientHasPrivilegs = bool.TryParse(dataParsed.privilege.ToString(), out isClientHasPrivilegs);
            if (!parseIsClientHasPrivilegs)
            {
                isClientHasPrivilegs = false;
                responseToClient.responseType = ResponseType.Bad;
                responseToClient.responseText = "Не вдалося отримати дані про Ваші пільги. " + defaultConfigMessage + " \"Відсутні\".";
                warnings.Add(responseToClient);
            }
            conditionsForDocument.IsClientHasPrivilegs = isDriverWasInAccident;

            int documentAdditionalLimits;
            bool parseDocumentAdditionalLimits = int.TryParse(dataParsed.osagoLimits.ToString(), out documentAdditionalLimits);
            if (!parseDocumentAdditionalLimits)
            {
                documentAdditionalLimits = 0;
                responseToClient.responseType = ResponseType.Bad;
                responseToClient.responseText = "Не вдалося отримати дані про Ваше бажання збільшити ліміти відповідальності. " + defaultConfigMessage + " \"Не збільшувати\".";
                warnings.Add(responseToClient);
            }
            conditionsForDocument.DocumentAdditionalLimits = documentAdditionalLimits;

            List<CompanyToSend> companiesToSend = new List<CompanyToSend>();

            var companies = db.Company.Select(c => c.Name).ToList();
            foreach(var c in companies)
            {
                CompanyToSend company= new CompanyToSend();
                company.CompanyName = c;

                companiesToSend.Add(company);
            }

            if(warnings.Count > 0)
            {
                DataWithWarningToSend dataWithWarningToSend = new DataWithWarningToSend();
                dataWithWarningToSend.CompaniesToSend = companiesToSend;
                dataWithWarningToSend.ErrorMessagesToClients = warnings;

                return js.Serialize(dataWithWarningToSend);
            }

            return js.Serialize(companiesToSend);
        }

        private class DataWithWarningToSend
        {
            public List<CompanyToSend> CompaniesToSend { get; set; }
            public List<ResponseToClient> ErrorMessagesToClients { get; set; }
        }

        private class CompanyToSend
        {
            public string CompanyName { get; set; }
            //continue this class in next push
        }

        private dynamic GetPotsRequestBody()
        {
            System.IO.Stream request = Request.InputStream;
            request.Seek(0, SeekOrigin.Begin);
            string bodyData = new StreamReader(request).ReadToEnd();
            return JsonConvert.DeserializeObject(bodyData);
        }

        private void GetPlaceOfRegistration(dynamic dataParsed, ref CityOfRegistration cityOfRegistration, ref CountryOfRegistration countryOfRegistration)
        {
            if (dataParsed.place.placeType == "code")
            {
                int currentCode = Convert.ToInt32(dataParsed.place.code.codeNum);
                TSC tsc = db.TSC.Where(t => t.Code == currentCode).First();
                cityOfRegistration = tsc.CityOfRegistration;
            }
            if (dataParsed.place.placeType == "address")
            {
                if (dataParsed.place.foreign == "false")
                {
                    string currentCity = Convert.ToString(dataParsed.place.city);
                    cityOfRegistration = db.CityOfRegistration.Where(c => c.Name == currentCity).First();
                }
                else
                {
                    string currentCountry = Convert.ToString(dataParsed.place.foreign);
                    countryOfRegistration = db.CountryOfRegistration.Where(c => c.Name == currentCountry).First();
                }
            }
        }

        private class Transport
        {
            public CarGlobalType Type { get; set; }
            public CarInsuranceType SubType { get; set; }
        }

        private class PlaceOfRegistration
        {
            public CityOfRegistration CityOfRegistration { get; set; }
            public CountryOfRegistration CountryOfRegistration { get; set; }
        }

        private class PeriodOfDocument
        {
            public double Period { get; set; }
            //Mandatory Technical Control (in rus OTK)
            public bool isMTC { get; set; }
        }

        private class DriverAccident
        {
            public bool IsDriverWasInAccident { get; set; }
            public int LastAccidentYear { get; set; }
        }

        private class ConditionsForDocument
        {
            public Transport Transport { get; set; }
            public PlaceOfRegistration PlaceOfRegistration { get; set; }
            public bool IsLegalEntity { get; set; }
            public PeriodOfDocument PeriodOfDocument { get; set; }
            public bool IsUseAsTaxi { get; set; }
            public DriverAccident DriverAccident { get; set; }
            public bool IsClientHasPrivilegs { get; set; }
            public int DocumentAdditionalLimits { get; set; }
        }

        private class TSCToSend
        {
            public int codeNum { get; set; }
            public string cityName { get; set; }
            public string regionName { get; set; }
        }
    }
}