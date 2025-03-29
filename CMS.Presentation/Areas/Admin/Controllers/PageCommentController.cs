using CMS.Application.Services.Implementations;
using CMS.Application.Services.Interfaces;
using CMS.Domain.Dtoes.PageComment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMS.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class PageCommentController : Controller
    {
        private readonly IPageCommentService _pageCommentService;
        private readonly IPageService _pageService;
        public PageCommentController(IPageCommentService pageCommentService, IPageService pageService)
        {
           _pageCommentService = pageCommentService;
            _pageService = pageService;
        }
        public IActionResult Index(int pageid=2)
        {
            ViewBag.TitleName = new SelectList(_pageService.GetPages().pageList, "PageId", "Title", pageid);
            var model = _pageCommentService.GetPageCommentsByPageId(pageid);
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _pageCommentService.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = _pageCommentService.GetByIdForEdit(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditPageCommentDto edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }
            _pageCommentService.Update(edit);
            return RedirectToAction("Index",new { pageid = edit.PageId });
        }
        public IActionResult Delete(int id)
        {
            var model = _pageCommentService.GetByIdForDelete(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DeletePageCommentDto delete)
        {
            if (!ModelState.IsValid)
            {
                return View(delete);
            }
            _pageCommentService.Delete(delete);
            return RedirectToAction("Index", new { pageid = delete.PageId });
        }
    }
}
