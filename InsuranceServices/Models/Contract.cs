namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contract")]
    public partial class Contract
    {
        public int Id { get; set; }

        public int IdCompanyMiddleman { get; set; }

        public int IdContractType { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }

        public double SumLimitForHealthDamage { get; set; }

        public double SumLimitForPropertyDamage { get; set; }

        public int IdContractFranchise { get; set; }

        public int IdClient { get; set; }

        public int IdClientCar { get; set; }

        public double BaseCoef { get; set; }

        public int IdK1 { get; set; }

        public int IdK2 { get; set; }

        public int IdK3 { get; set; }

        public int IdK4 { get; set; }

        public int IdK5 { get; set; }

        public int IdK6 { get; set; }

        public int IdK7 { get; set; }

        public int IdBonusMalus { get; set; }

        public int IdDiscountByQuantity { get; set; }

        public int IdDiscountForClientWithPrivilegies { get; set; }

        public double ContractPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfIssued { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfPayment { get; set; }

        [StringLength(4000)]
        public string Note { get; set; }

        public virtual BonusMalus BonusMalus { get; set; }

        public virtual Client Client { get; set; }

        public virtual ClientCar ClientCar { get; set; }

        public virtual CompanyMiddleman CompanyMiddleman { get; set; }

        public virtual ContractType ContractType { get; set; }

        public virtual ContractFranchise ContractFranchise { get; set; }

        public virtual DiscountByQuantity DiscountByQuantity { get; set; }

        public virtual DiscountForClientWithPrivilegies DiscountForClientWithPrivilegies { get; set; }

        public virtual K1 K1 { get; set; }

        public virtual K2 K2 { get; set; }

        public virtual K3 K3 { get; set; }

        public virtual K4 K4 { get; set; }

        public virtual K5 K5 { get; set; }

        public virtual K6 K6 { get; set; }

        public virtual K7 K7 { get; set; }
    }
}
