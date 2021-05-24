using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_Blogging.ModelEnity
{
    [Table("Comments")]
    public class Comments
    {
        [Column("CommentId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CommentId { get; set; }

        [Column("Name")]
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [Column("CommentDate")]
        [Required]
        public DateTime CommentDate { get; set; }

        [Column("Comment")]
        [Required]
        public string Comment { get; set; } 
    }
}
