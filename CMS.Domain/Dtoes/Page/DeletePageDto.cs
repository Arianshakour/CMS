using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Dtoes.Page
{
    public class DeletePageDto
    {
        public int PageId { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }
        [Display(Name = "دسته بندی خبر")]
        public string GroupTitle { get; set; }
        [Display(Name = "ایدی دسته بندی خبر")]
        public int PageGroupId { get; set; }

    }
}
