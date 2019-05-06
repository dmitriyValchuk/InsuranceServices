namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CountryOfRegistration")]
    public partial class CountryOfRegistration
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }
    }
}
