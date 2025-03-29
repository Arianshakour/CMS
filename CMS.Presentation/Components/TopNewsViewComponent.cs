using CMS.Application.Services.Implementations;
using CMS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Components
{
    public class TopNewsViewComponent : ViewComponent
    {
        private readonly IPageService _pageService;
        public TopNewsViewComponent(IPageService pageService)
        {
            _pageService = pageService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _pageService.TopNews();
            return View("TopNews", model);
        }
    }
}
