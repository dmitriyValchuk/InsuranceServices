namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyDetail")]
    public partial class CompanyDetail
    {
        public int Id { get; set; }

        public int IdCompany { get; set; }

        [Required]
        [StringLength(13)]
        public string Phone { get; set; }

        [StringLength(13)]
        public string Phone2 { get; set; }

        [Required]
        [StringLength(4000)]
        public string Description { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int SummaryRait { get; set; }

        public int MTSBU_SummaryRait { get; set; }

        public int MTSBU_UregulationRait { get; set; }

        public int MTSBU_ComplaintLevel { get; set; }

        public virtual Company Company { get; set; }
    }
}
