namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyFeature")]
    public partial class CompanyFeature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyFeature()
        {
            CompanyFeatureToCompany = new HashSet<CompanyFeatureToCompany>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Icon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyFeatureToCompany> CompanyFeatureToCompany { get; set; }
    }
}
