using CMS.Application.Services.Interfaces;
using CMS.Domain.Common;
using CMS.Domain.Dtoes.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace CMS.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IPageGroupService _pageGroupService;
        public PageController(IPageService pageService, IPageGroupService pageGroupService)
        {
            _pageService = pageService;
            _pageGroupService = pageGroupService;
        }
        public IActionResult Index(int gId=1)
        {
            ViewBag.GroupName = new SelectList(_pageGroupService.GetPageGroups().pageGroupList, "GroupId", "GroupTitle", gId);
            var model = _pageService.GetPagesById(gId);
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_gridPage", model);
            }
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.GroupId = new SelectList(_pageGroupService.GetPageGroups().pageGroupList, "GroupId", "GroupTitle");
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(CreatePageDto create)
        {
            if (!ModelState.IsValid)
            {
                //parameter 4 khat zir baraye negah dashtan meqdari ast ke karbar zade
                ViewBag.GroupId = new SelectList(_pageGroupService.GetPageGroups().pageGroupList, "GroupId", "GroupTitle", create.PageGroupId);
                //return View(create);
                string v1 = ViewRendererUtils.RenderRazorViewToString(this, "~/Areas/Admin/Views/Page/Create.cshtml", create);
                return Json(new { view = v1, success = false });
            }
            if (create.ImgUp != null)
            {
                create.ImageName = Guid.NewGuid() + Path.GetExtension(create.ImgUp.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PageImages", create.ImageName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    create.ImgUp.CopyTo(stream);
                }
            }
            _pageService.Insert(create);
            return RedirectToAction("Index", new { gId = create.PageGroupId });
        }
        public IActionResult Detail(int id)
        {
            var model = _pageService.GetPage(id);
            if (model == null)
            {
                return BadRequest();
            }
            return PartialView(model);
        }
        public IActionResult Edit(int id)
        {
            var model = _pageService.GetPageForEdit(id);
            if (model == null)
            {
                return BadRequest();
            }
            ViewBag.GroupId = new SelectList(_pageGroupService.GetPageGroups().pageGroupList, "GroupId", "GroupTitle", model.PageGroupId);
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult Edit(EditPageDto edit)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GroupId = new SelectList(_pageGroupService.GetPageGroups().pageGroupList, "GroupId", "GroupTitle", edit.PageGroupId);
                //return View(edit);
                string v1 = ViewRendererUtils.RenderRazorViewToString(this, "~/Areas/Admin/Views/Page/Edit.cshtml", edit);
                return Json(new { view = v1, success = false });
            }
            if (edit.imgUp != null)
            {
                var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PageImages", edit.ImageName);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
                edit.ImageName = Guid.NewGuid() + Path.GetExtension(edit.imgUp.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PageImages", edit.ImageName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    edit.imgUp.CopyTo(stream);
                }
            }
            _pageService.Update(edit);
            return RedirectToAction("Index",new { gId = edit.PageGroupId });
        }
        public IActionResult Delete(int id)
        {
            var model = _pageService.GetPageForDelete(id);
            if (model == null)
            {
                return BadRequest();
            }
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult Delete(DeletePageDto delete)
        {
            if (delete.ImageName != null)
            {
                var removeImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PageImages", delete.ImageName);
                if (System.IO.File.Exists(removeImagePath))
                {
                    System.IO.File.Delete(removeImagePath);
                }
            }
            _pageService.Delete(delete);
            return RedirectToAction("Index", new { gId = delete.PageGroupId });
        }
    }
}
