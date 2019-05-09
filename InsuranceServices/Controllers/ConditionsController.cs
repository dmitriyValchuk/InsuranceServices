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
            dynamic dataParsed = GetPotsRequestBody();
            JavaScriptSerializer js = new JavaScriptSerializer();

            Transport transport = new Transport();
            //Type will be as A 1/A 2/B 1/B 2
            transport.Type = dataParsed.trans.type;
            transport.SubType = dataParsed.trans.extra;

            //CarGlobalType carGlobalType = db.CarGlobalType.Where(c => c.Name == transport.Type).First();
            CarInsuranceType carInsuranceType = db.CarInsuranceType.Where(c => c.Type == transport.SubType).First();

            CityOfRegistration cityOfRegistration = new CityOfRegistration();
            CountryOfRegistration countryOfRegistration = new CountryOfRegistration();

            GetPlaceOfRegistration(dataParsed, ref cityOfRegistration, ref countryOfRegistration);

            //check write in variable
            var a = cityOfRegistration.Name;
            var b = countryOfRegistration.Name;

            return js.Serialize("");
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
            public string Type { get; set; }
            public string SubType { get; set; }
        }

        private class TSCToSend
        {
            public int codeNum { get; set; }
            public string cityName { get; set; }
            public string regionName { get; set; }
        }
    }
}