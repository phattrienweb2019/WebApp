namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            Tests = new HashSet<Test>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int? CategoryId { get; set; }

        public int LevelId { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public virtual Category Category { get; set; }

        public virtual Level Level { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
