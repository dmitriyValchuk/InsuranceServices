namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarGlobalType")]
    public partial class CarGlobalType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarGlobalType()
        {
            CarGlobalToInsuranceType = new HashSet<CarGlobalToInsuranceType>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarGlobalToInsuranceType> CarGlobalToInsuranceType { get; set; }
    }
}
