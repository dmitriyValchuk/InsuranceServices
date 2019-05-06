namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chart")]
    public partial class Chart
    {
        public int Id { get; set; }

        public int IdCompany { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Year { get; set; }

        public int QUARTER { get; set; }

        public virtual Company Company { get; set; }
    }
}
