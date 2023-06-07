namespace Practika
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        [StringLength(50)]
        public string FIO { get; set; }

        [Required]
        [StringLength(50)]
        public string Dolzhnost { get; set; }

        public int TableID { get; set; }

        [Required]
        [StringLength(30)]
        public string Login { get; set; }

        [Required]
        [StringLength(30)]
        public string Pass { get; set; }
    }
}
