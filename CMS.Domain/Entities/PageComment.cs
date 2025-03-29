using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class PageComment
    {
        [Key]
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsShow { get; set; }

        
        [ForeignKey("PageId")]
        public Page? page { get; set; }
        public int PageId { get; set; }
    }
}
