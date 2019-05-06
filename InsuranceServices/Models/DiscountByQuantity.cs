namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscountByQuantity")]
    public partial class DiscountByQuantity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiscountByQuantity()
        {
            Contract = new HashSet<Contract>();
        }

        public int Id { get; set; }

        public bool IsLegalEntity { get; set; }

        public int TransportCountFrom { get; set; }

        public int TransportCountTo { get; set; }

        public double Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contract { get; set; }
    }
}
