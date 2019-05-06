namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyIMG")]
    public partial class CompanyIMG
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdImageType { get; set; }

        [Required]
        [StringLength(500)]
        public string Path { get; set; }

        public int IdCompany { get; set; }

        [Required]
        [StringLength(500)]
        public string ReferensToCompanyPage { get; set; }

        public virtual Company Company { get; set; }

        public virtual ImageType ImageType { get; set; }
    }
}
