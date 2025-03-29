using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ViewModels
{
    public class PageViewModel
    {
        public Page page { get; set; }
        public List<Page> pageList { get; set; }
        public PageViewModel()
        {
            page = new Page();
            pageList = new List<Page>();
        }
    }
}
