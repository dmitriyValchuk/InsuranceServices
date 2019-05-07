using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using InsuranceServices.Models;

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

        public string GetRegionAndCityOfRegistration(int codeTSC)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            int idCityOfRegistration = db.TSC.Where(tsc => tsc.Code == codeTSC).Select(tsc => tsc.Id).First();

            string cityOfRegistration = db.CityOfRegistration.Where(c => c.Id == idCityOfRegistration).Select(c => c.Name).ToString();

            int? idRegionOgregistration = db.CityOfRegistration.Where(c => c.Id == idCityOfRegistration).Select(c => c.IdRegioneOfRegistration).First();

            string regionOfRegistration = db.RegioneOfRegistration.Where(r => r.Id == idCityOfRegistration).Select(r => r.Name).First();
            List<string> dataToSend = new List<string>();
            dataToSend.Add(regionOfRegistration);
            dataToSend.Add(cityOfRegistration);
            return js.Serialize(dataToSend);
        }
    }
}