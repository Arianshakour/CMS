using CMS.Application.Services.Implementations;
using CMS.Application.Services.Interfaces;
using CMS.Domain.Common;
using CMS.Domain.Dtoes.PageGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class PageGroupController : Controller
    {
        private readonly IPageGroupService _pageGroupService;
        public PageGroupController(IPageGroupService pageGroupService)
        {
            _pageGroupService = pageGroupService;
        }
        public IActionResult Index()
        {
            var model = _pageGroupService.GetPageGroups();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_gridPageGroup",model);
            }
            return View(model);
        }
        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(CreatePageGroupDto create)
        {
            if (!ModelState.IsValid)
            {
                //return View(create);
                string v1 = ViewRendererUtils.RenderRazorViewToString(this, "~/Areas/Admin/Views/PageGroup/Create.cshtml", create);
                return Json(new { view = v1, success = false });
            }
            _pageGroupService.Insert(create);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var model = _pageGroupService.GetPageGroup(id);
            if (model == null)
            {
                return BadRequest();
            }
            return PartialView(model);
        }
        public IActionResult Edit(int id)
        {
            var model = _pageGroupService.GetPageGroupForEdit(id);
            if (model == null)
            {
                return BadRequest();
            }
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult Edit(EditPageGroupDto edit)
        {
            if (!ModelState.IsValid)
            {
                //return View(edit);
                string v1 = ViewRendererUtils.RenderRazorViewToString(this, "~/Areas/Admin/Views/PageGroup/Edit.cshtml", edit);
                return Json(new { view = v1, success = false });
            }
            _pageGroupService.Update(edit);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var model = _pageGroupService.GetPageGroupForDelete(id);
            if (model == null)
            {
                return BadRequest();
            }
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult Delete(DeletePageGroupDto delete)
        {
            _pageGroupService.Delete(delete);
            return RedirectToAction("Index");
        }
    }
}
