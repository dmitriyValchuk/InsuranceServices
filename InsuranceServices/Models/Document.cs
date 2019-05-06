namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Document")]
    public partial class Document
    {
        public int Id { get; set; }

        public int IdDocumentType { get; set; }

        public int IdClient { get; set; }

        [StringLength(10)]
        public string Series { get; set; }

        [Required]
        [StringLength(20)]
        public string Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [StringLength(200)]
        public string IssueBy { get; set; }

        public virtual Client Client { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}
