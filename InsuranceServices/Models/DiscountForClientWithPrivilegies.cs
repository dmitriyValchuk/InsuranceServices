namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DiscountForClientWithPrivilegies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiscountForClientWithPrivilegies()
        {
            Contract = new HashSet<Contract>();
        }

        public int Id { get; set; }

        public int IdDocumentType { get; set; }

        public double? Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contract { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}
