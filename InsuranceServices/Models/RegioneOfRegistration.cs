namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegioneOfRegistration")]
    public partial class RegioneOfRegistration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegioneOfRegistration()
        {
            CityOfRegistration = new HashSet<CityOfRegistration>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CityOfRegistration> CityOfRegistration { get; set; }
    }
}
