namespace Practika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechnicalData")]
    public partial class TechnicalData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int IdTypeBody { get; set; }

        public int CountDoor { get; set; }

        public int IdTypeEngine { get; set; }

        [Required]
        [StringLength(50)]
        public string LocationEngine { get; set; }

        public decimal WorkScopeEngine { get; set; }

        public int CodeProduct { get; set; }

        public virtual Product Product { get; set; }

        public virtual TypeBody TypeBody { get; set; }

        public virtual TypeEngine TypeEngine { get; set; }
    }
}
