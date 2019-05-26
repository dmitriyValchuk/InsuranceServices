namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IndividualClient")]
    public partial class IndividualClient
    {
        public int Id { get; set; }

        public int IdClient { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [StringLength(10)]
        public string PersonalCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public virtual Client Client { get; set; }
    }
}
