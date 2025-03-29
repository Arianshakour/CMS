using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(350)]
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public int Visit { get; set; }
        public string ImageName { get; set; }
        public bool ShowInSlider { get; set; }
        public DateTime CreateDate { get; set; }
        public string Tags { get; set; }



        public List<PageComment> PageComments { get; set; } = new List<PageComment>();
        [ForeignKey("PageGroupId")]
        public PageGroup pagegroup { get; set; }
        public int PageGroupId { get; set; }
    }
}
