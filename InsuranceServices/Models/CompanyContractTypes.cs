namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyContractTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyContractTypes()
        {
            ContractFranchise = new HashSet<ContractFranchise>();
        }

        public int Id { get; set; }

        public int IdCompanyMiddleman { get; set; }

        public int IdContractType { get; set; }

        public virtual CompanyMiddleman CompanyMiddleman { get; set; }

        public virtual ContractType ContractType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractFranchise> ContractFranchise { get; set; }
    }
}
