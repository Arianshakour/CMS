using CMS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Components
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly IPageService _pageService;
        public SliderViewComponent(IPageService pageService)
        {
            _pageService = pageService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _pageService.Slider();
            return View("Slider", model);
        }
    }
}
