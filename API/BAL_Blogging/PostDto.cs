using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BAL_Blogging
{
    public class PostDto
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        [MaxLength(200)]
        public string PostTitle { get; set; }

        [Required]
        public string PostContent { get; set; }

        [MaxLength(150)]
        [Required]
        public string PostAuthor { get; set; }


        public bool IsDeleted { get; set; } = false;
    }
}
