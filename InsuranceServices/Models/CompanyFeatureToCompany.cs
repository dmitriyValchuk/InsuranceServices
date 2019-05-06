namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyFeatureToCompany")]
    public partial class CompanyFeatureToCompany
    {
        public int Id { get; set; }

        public int IdCompany { get; set; }

        public int IdFeature { get; set; }

        public virtual Company Company { get; set; }

        public virtual CompanyFeature CompanyFeature { get; set; }
    }
}
