namespace InsuranceServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarGlobalToInsuranceType")]
    public partial class CarGlobalToInsuranceType
    {
        public int Id { get; set; }

        public int IdGlobalType { get; set; }

        public int IdInsuraceType { get; set; }

        public virtual CarGlobalType CarGlobalType { get; set; }

        public virtual CarInsuranceType CarInsuranceType { get; set; }
    }
}
