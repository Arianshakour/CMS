using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class PageGroup
    {
        [Key]
        public int GroupId { get; set; }
        [MaxLength(200)]
        public string GroupTitle { get; set; }

        public List<Page> pages { get; set; } = new List<Page>();
    }
}
