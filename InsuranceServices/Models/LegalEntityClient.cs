namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LegalEntityClient")]
    public partial class LegalEntityClient
    {
        public int Id { get; set; }

        public int IdClient { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(8)]
        public string EDRPOU { get; set; }

        public virtual Client Client { get; set; }
    }
}
