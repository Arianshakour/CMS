using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Dtoes.PageComment
{
    public class EditPageCommentDto
    {
        public int CommentId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(150)]
        public string Email { get; set; }
        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Comment { get; set; }
        [Display(Name = "نمایش داده شود ؟")]
        public bool IsShow { get; set; }
        [Display(Name = "عنوان خبر")]
        public string PageName { get; set; }
        [Display(Name = "عنوان دسته بندی")]
        public string GroupName { get; set; }
        public int PageId { get; set; }
    }
}
