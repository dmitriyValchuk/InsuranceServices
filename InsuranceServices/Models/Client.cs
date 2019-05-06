namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            ClientCar = new HashSet<ClientCar>();
            Contract = new HashSet<Contract>();
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }

        public bool IsLegalEntity { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [StringLength(150)]
        public string EntityName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string PersonalCode { get; set; }

        [StringLength(10)]
        public string EDRPOU { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        public int? IdPrivileges { get; set; }

        public virtual Privileges Privileges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientCar> ClientCar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Document { get; set; }
    }
}
