namespace InsuranceServices.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InsuranceServicesContext : DbContext
    {
        public InsuranceServicesContext()
            : base("name=InsuranceServicesContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<BonusMalus> BonusMalus { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarGlobalToInsuranceType> CarGlobalToInsuranceType { get; set; }
        public virtual DbSet<CarGlobalType> CarGlobalType { get; set; }
        public virtual DbSet<CarInsuranceType> CarInsuranceType { get; set; }
        public virtual DbSet<Chart> Chart { get; set; }
        public virtual DbSet<CityOfRegistration> CityOfRegistration { get; set; }
        public virtual DbSet<CityOrCountryOfRegToZone> CityOrCountryOfRegToZone { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientCar> ClientCar { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyContractTypes> CompanyContractTypes { get; set; }
        public virtual DbSet<CompanyDetail> CompanyDetail { get; set; }
        public virtual DbSet<CompanyFeature> CompanyFeature { get; set; }
        public virtual DbSet<CompanyFeatureToCompany> CompanyFeatureToCompany { get; set; }
        public virtual DbSet<CompanyIMG> CompanyIMG { get; set; }
        public virtual DbSet<CompanyMiddleman> CompanyMiddleman { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractFranchise> ContractFranchise { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<CountryOfRegistration> CountryOfRegistration { get; set; }
        public virtual DbSet<DiscountByQuantity> DiscountByQuantity { get; set; }
        public virtual DbSet<DiscountForClientWithPrivilegies> DiscountForClientWithPrivilegies { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Franchise> Franchise { get; set; }
        public virtual DbSet<ImageType> ImageType { get; set; }
        public virtual DbSet<InsuranceZoneOfRegistration> InsuranceZoneOfRegistration { get; set; }
        public virtual DbSet<K1> K1 { get; set; }
        public virtual DbSet<K2> K2 { get; set; }
        public virtual DbSet<K3> K3 { get; set; }
        public virtual DbSet<K4> K4 { get; set; }
        public virtual DbSet<K5> K5 { get; set; }
        public virtual DbSet<K6> K6 { get; set; }
        public virtual DbSet<K7> K7 { get; set; }
        public virtual DbSet<Middleman> Middleman { get; set; }
        public virtual DbSet<Privileges> Privileges { get; set; }
        public virtual DbSet<RegioneOfRegistration> RegioneOfRegistration { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TSC> TSC { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BonusMalus>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.BonusMalus)
                .HasForeignKey(e => e.IdBonusMalus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.ClientCar)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.IdCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarGlobalType>()
                .HasMany(e => e.CarGlobalToInsuranceType)
                .WithRequired(e => e.CarGlobalType)
                .HasForeignKey(e => e.IdGlobalType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarInsuranceType>()
                .HasMany(e => e.BonusMalus)
                .WithOptional(e => e.CarInsuranceType)
                .HasForeignKey(e => e.IdCarInsuranceType);

            modelBuilder.Entity<CarInsuranceType>()
                .HasMany(e => e.Car)
                .WithOptional(e => e.CarInsuranceType)
                .HasForeignKey(e => e.IdCarInsuranceType);

            modelBuilder.Entity<CarInsuranceType>()
                .HasMany(e => e.CarGlobalToInsuranceType)
                .WithRequired(e => e.CarInsuranceType)
                .HasForeignKey(e => e.IdInsuraceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarInsuranceType>()
                .HasMany(e => e.K1)
                .WithRequired(e => e.CarInsuranceType)
                .HasForeignKey(e => e.IdCarInsuranceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarInsuranceType>()
                .HasMany(e => e.K2)
                .WithRequired(e => e.CarInsuranceType)
                .HasForeignKey(e => e.IdCarInsuranceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarInsuranceType>()
                .HasMany(e => e.K3)
                .WithRequired(e => e.CarInsuranceType)
                .HasForeignKey(e => e.IdCarInsuranceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CityOfRegistration>()
                .HasMany(e => e.CityOrCountryOfRegToZone)
                .WithOptional(e => e.CityOfRegistration)
                .HasForeignKey(e => e.IdCityOfRegistration);

            modelBuilder.Entity<CityOfRegistration>()
                .HasMany(e => e.TSC)
                .WithRequired(e => e.CityOfRegistration)
                .HasForeignKey(e => e.IdCityOfRegistration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ClientCar)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Document)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClientCar>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.ClientCar)
                .HasForeignKey(e => e.IdClientCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Chart)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CityOrCountryOfRegToZone)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyDetail)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyFeatureToCompany)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyIMG)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyMiddleman)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyContractTypes>()
                .HasMany(e => e.ContractFranchise)
                .WithRequired(e => e.CompanyContractTypes)
                .HasForeignKey(e => e.IdCompanyContractType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyFeature>()
                .HasMany(e => e.CompanyFeatureToCompany)
                .WithRequired(e => e.CompanyFeature)
                .HasForeignKey(e => e.IdFeature)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyMiddleman>()
                .HasMany(e => e.BonusMalus)
                .WithRequired(e => e.CompanyMiddleman)
                .HasForeignKey(e => e.IdCompanyMiddleman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyMiddleman>()
                .HasMany(e => e.CompanyContractTypes)
                .WithRequired(e => e.CompanyMiddleman)
                .HasForeignKey(e => e.IdCompanyMiddleman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyMiddleman>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.CompanyMiddleman)
                .HasForeignKey(e => e.IdCompanyMiddleman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyMiddleman>()
                .HasMany(e => e.K1)
                .WithOptional(e => e.CompanyMiddleman)
                .HasForeignKey(e => e.IdCompanyMiddleman);

            modelBuilder.Entity<CompanyMiddleman>()
                .HasMany(e => e.K2)
                .WithRequired(e => e.CompanyMiddleman)
                .HasForeignKey(e => e.IdCompanyMiddleman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyMiddleman>()
                .HasMany(e => e.K3)
                .WithRequired(e => e.CompanyMiddleman)
                .HasForeignKey(e => e.IdCompanyMiddleman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyMiddleman>()
                .HasMany(e => e.K4)
                .WithRequired(e => e.CompanyMiddleman)
                .HasForeignKey(e => e.IdCompanyMiddleman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractFranchise>()
                .HasMany(e => e.BonusMalus)
                .WithRequired(e => e.ContractFranchise)
                .HasForeignKey(e => e.IdContractFranchise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractFranchise>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.ContractFranchise)
                .HasForeignKey(e => e.IdContractFranchise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractFranchise>()
                .HasMany(e => e.K2)
                .WithRequired(e => e.ContractFranchise)
                .HasForeignKey(e => e.IdContractFranchise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractFranchise>()
                .HasMany(e => e.K4)
                .WithRequired(e => e.ContractFranchise)
                .HasForeignKey(e => e.IdContractFranchise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractType>()
                .HasMany(e => e.CompanyContractTypes)
                .WithRequired(e => e.ContractType)
                .HasForeignKey(e => e.IdContractType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractType>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.ContractType)
                .HasForeignKey(e => e.IdContractType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiscountByQuantity>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.DiscountByQuantity)
                .HasForeignKey(e => e.IdDiscountByQuantity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiscountForClientWithPrivilegies>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.DiscountForClientWithPrivilegies)
                .HasForeignKey(e => e.IdDiscountForClientWithPrivilegies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocumentType>()
                .HasMany(e => e.DiscountForClientWithPrivilegies)
                .WithRequired(e => e.DocumentType)
                .HasForeignKey(e => e.IdDocumentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocumentType>()
                .HasMany(e => e.Document)
                .WithRequired(e => e.DocumentType)
                .HasForeignKey(e => e.IdDocumentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Franchise>()
                .HasMany(e => e.ContractFranchise)
                .WithRequired(e => e.Franchise)
                .HasForeignKey(e => e.IdFranchise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ImageType>()
                .HasMany(e => e.CompanyIMG)
                .WithRequired(e => e.ImageType)
                .HasForeignKey(e => e.IdImageType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceZoneOfRegistration>()
                .HasMany(e => e.BonusMalus)
                .WithRequired(e => e.InsuranceZoneOfRegistration)
                .HasForeignKey(e => e.IdInsuranceZoneOfReg)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceZoneOfRegistration>()
                .HasMany(e => e.CityOfRegistration)
                .WithOptional(e => e.InsuranceZoneOfRegistration)
                .HasForeignKey(e => e.IdZoneOfRegistration);

            modelBuilder.Entity<InsuranceZoneOfRegistration>()
                .HasMany(e => e.CityOrCountryOfRegToZone)
                .WithOptional(e => e.InsuranceZoneOfRegistration)
                .HasForeignKey(e => e.IdInsuranceZoneOfReg);

            modelBuilder.Entity<InsuranceZoneOfRegistration>()
                .HasMany(e => e.CountryOfRegistration)
                .WithOptional(e => e.InsuranceZoneOfRegistration)
                .HasForeignKey(e => e.IdZoneOfRegistration);

            modelBuilder.Entity<InsuranceZoneOfRegistration>()
                .HasMany(e => e.K2)
                .WithRequired(e => e.InsuranceZoneOfRegistration)
                .HasForeignKey(e => e.IdInsuranceZoneOfReg)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceZoneOfRegistration>()
                .HasMany(e => e.K3)
                .WithRequired(e => e.InsuranceZoneOfRegistration)
                .HasForeignKey(e => e.IdInsuranceZoneOfReg)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceZoneOfRegistration>()
                .HasMany(e => e.K4)
                .WithRequired(e => e.InsuranceZoneOfRegistration)
                .HasForeignKey(e => e.IdInsuranceZoneOfReg)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<K1>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.K1)
                .HasForeignKey(e => e.IdK1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<K2>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.K2)
                .HasForeignKey(e => e.IdK2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<K3>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.K3)
                .HasForeignKey(e => e.IdK3)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<K4>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.K4)
                .HasForeignKey(e => e.IdK4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<K5>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.K5)
                .HasForeignKey(e => e.IdK5)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<K6>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.K6)
                .HasForeignKey(e => e.IdK6)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<K7>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.K7)
                .HasForeignKey(e => e.IdK7)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Middleman>()
                .HasMany(e => e.CompanyMiddleman)
                .WithRequired(e => e.Middleman)
                .HasForeignKey(e => e.IdMiddleman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Privileges>()
                .HasMany(e => e.Client)
                .WithOptional(e => e.Privileges)
                .HasForeignKey(e => e.IdPrivileges);

            modelBuilder.Entity<RegioneOfRegistration>()
                .HasMany(e => e.CityOfRegistration)
                .WithOptional(e => e.RegioneOfRegistration)
                .HasForeignKey(e => e.IdRegioneOfRegistration);

            modelBuilder.Entity<TSC>()
                .HasMany(e => e.CityOrCountryOfRegToZone)
                .WithOptional(e => e.TSC)
                .HasForeignKey(e => e.IdTSC);
        }
    }
}
