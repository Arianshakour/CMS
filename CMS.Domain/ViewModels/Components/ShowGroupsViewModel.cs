using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ViewModels.Components
{
    public class ShowGroupsViewModel
    {
        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
        //tedad khabar haye dakhel har daste
        public int PageCount { get; set; }
    }
}
