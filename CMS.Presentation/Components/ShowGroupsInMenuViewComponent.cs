using CMS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Components
{
    public class ShowGroupsInMenuViewComponent : ViewComponent
    {
        private readonly IPageGroupService _pageGroupService;
        public ShowGroupsInMenuViewComponent(IPageGroupService pageGroupService)
        {
            _pageGroupService = pageGroupService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _pageGroupService.GetPageGroupsForComponents();
            return View("ShowGroupsInMenu", model);
        }
    }
}
