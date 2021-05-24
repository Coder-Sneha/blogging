using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_Blogging.ModelEnity
{
    [Table("Posts")]
    public class Post
    {
        [Column("PostId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PostId { get; set; }

        [Column("PostTitle")]
        [Required]
        [MaxLength(200)]
        public string PostTitle { get; set; }

        [Column("DatePosted")]
        [Required]
        public DateTime DatePosted { get; set; }

        [Column("DateEdited")]
        public DateTime DateEdited { get; set; }

        [Column("PostContent")]
        [Required]
        public string PostContent { get; set; }

        [Column("PostAuthor")]
        [MaxLength(150)]
        [Required]
        public string PostAuthor { get; set; }

        [Required]
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("PostId")]
        public virtual List<Comments> Comments { get; set; }
    }
}
