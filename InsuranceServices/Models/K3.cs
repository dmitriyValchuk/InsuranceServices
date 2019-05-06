namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class K3
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public K3()
        {
            Contract = new HashSet<Contract>();
        }

        public int Id { get; set; }

        public int IdCompanyMiddleman { get; set; }

        public bool IsLegalEntity { get; set; }

        public int IdCarInsuranceType { get; set; }

        public double Value { get; set; }

        public int IdInsuranceZoneOfReg { get; set; }

        public virtual CarInsuranceType CarInsuranceType { get; set; }

        public virtual CompanyMiddleman CompanyMiddleman { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contract { get; set; }

        public virtual InsuranceZoneOfRegistration InsuranceZoneOfRegistration { get; set; }
    }
}
