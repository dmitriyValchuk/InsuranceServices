namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            ClientCar = new HashSet<ClientCar>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Mark { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(20)]
        public string CarKit { get; set; }

        public double? EngineCapacity { get; set; }

        [StringLength(10)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(17)]
        public string VIN_Code { get; set; }

        public int GraduationYear { get; set; }

        [StringLength(80)]
        public string PlaceOfRegistration { get; set; }

        public double? LoadCapacity { get; set; }

        public int? NumberOfSeats { get; set; }

        public bool? IsForTruck { get; set; }

        public int? IdCarInsuranceType { get; set; }

        public virtual CarInsuranceType CarInsuranceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientCar> ClientCar { get; set; }
    }
}
