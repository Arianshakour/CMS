using CMS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Components
{
    public class ShowGroupsViewComponent : ViewComponent
    {
        private readonly IPageGroupService _pageGroupService;
        public ShowGroupsViewComponent(IPageGroupService pageGroupService)
        {
            _pageGroupService = pageGroupService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _pageGroupService.GetPageGroupsForComponents();
            return View("ShowGroups", model);
        }
    }
}
