namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CityOrCountryOfRegToZone")]
    public partial class CityOrCountryOfRegToZone
    {
        public int Id { get; set; }

        public bool IsUkraine { get; set; }

        public int IdCompany { get; set; }

        public int? IdTSC { get; set; }

        public int? IdInsuranceZoneOfReg { get; set; }

        public int? IdCityOfRegistration { get; set; }

        public virtual CityOfRegistration CityOfRegistration { get; set; }

        public virtual Company Company { get; set; }

        public virtual InsuranceZoneOfRegistration InsuranceZoneOfRegistration { get; set; }

        public virtual TSC TSC { get; set; }
    }
}
