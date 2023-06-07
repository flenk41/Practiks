namespace Practika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchase")]
    public partial class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int CodeProduct { get; set; }

        public int IdClient { get; set; }

        public int idManeger { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatePuschase { get; set; }

        public bool Delivery { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentType { get; set; }

        public virtual Client Client { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual Product Product { get; set; }
    }
}
