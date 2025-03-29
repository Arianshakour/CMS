using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ViewModels
{
    public class PageCommentViewModel
    {
        public PageComment pageComment { get; set; }
        public List<PageComment> pageCommentList { get; set; }
        public PageCommentViewModel()
        {
            pageComment = new PageComment();
            pageCommentList = new List<PageComment>();
        }
    }
}
