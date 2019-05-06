namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TSC")]
    public partial class TSC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TSC()
        {
            CityOrCountryOfRegToZone = new HashSet<CityOrCountryOfRegToZone>();
        }

        public int Id { get; set; }

        public int IdCityOfRegistration { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public int Code { get; set; }

        public virtual CityOfRegistration CityOfRegistration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CityOrCountryOfRegToZone> CityOrCountryOfRegToZone { get; set; }
    }
}
