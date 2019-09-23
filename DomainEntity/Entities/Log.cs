namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string IP { get; set; }

        [StringLength(50)]
        public string Func { get; set; }

        [StringLength(50)]
        public string Action { get; set; }

        public DateTime? Time { get; set; }

        public virtual User User { get; set; }
    }
}
