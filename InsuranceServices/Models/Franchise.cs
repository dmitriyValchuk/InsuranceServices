namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Franchise")]
    public partial class Franchise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Franchise()
        {
            ContractFranchise = new HashSet<ContractFranchise>();
        }

        public int Id { get; set; }

        public double Sum { get; set; }

        [Required]
        [StringLength(10)]
        public string Currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractFranchise> ContractFranchise { get; set; }
    }
}
