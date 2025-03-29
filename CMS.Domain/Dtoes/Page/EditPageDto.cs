using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Dtoes.Page
{
    public class EditPageDto
    {
        public int PageId { get; set; }
        [Display(Name = "گروه خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PageGroupId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        [Display(Name = "توضیح مختصر")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "متن")]
        public string Text { get; set; }
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }
        //baraye daryaft tasvir elzami ast ke in khat ziro benevisi
        [Display(Name = "تصویر")]
        public IFormFile? imgUp { get; set; }
        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }
    }
}
