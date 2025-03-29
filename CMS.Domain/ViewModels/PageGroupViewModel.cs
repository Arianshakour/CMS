using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ViewModels
{
    public class PageGroupViewModel
    {
        public PageGroup pageGroup { get; set; }
        public List<PageGroup> pageGroupList { get; set; }
        public PageGroupViewModel()
        {
            pageGroup = new PageGroup();
            pageGroupList = new List<PageGroup>();
        }
    }
}
