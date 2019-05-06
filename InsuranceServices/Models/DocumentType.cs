namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocumentType")]
    public partial class DocumentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentType()
        {
            DiscountForClientWithPrivilegies = new HashSet<DiscountForClientWithPrivilegies>();
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool IsRightToBenefits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscountForClientWithPrivilegies> DiscountForClientWithPrivilegies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Document { get; set; }
    }
}
