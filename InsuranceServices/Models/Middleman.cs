namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Middleman")]
    public partial class Middleman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Middleman()
        {
            CompanyMiddleman = new HashSet<CompanyMiddleman>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string FullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyMiddleman> CompanyMiddleman { get; set; }
    }
}
