using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CMS.Presentation.Models;
using CMS.Application.Services.Interfaces;

namespace CMS.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IPageService _pageService;
    private readonly IPageCommentService _pageCommentService;
    public HomeController(IPageService pageService, IPageCommentService pageCommentService)
    {
        _pageService = pageService;
        _pageCommentService = pageCommentService;
    }

    public IActionResult Index(string? search)
    {
        if (string.IsNullOrEmpty(search))
        {
            var model = _pageService.LastNews();
            ViewBag.IsSearch = false;
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Index", model);
            }
            else
            {
                return View("Index", model);
            }
        }
        else
        {
            ViewBag.Name = search;
            ViewBag.IsSearch = true;
            var model = _pageService.Search(search);
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Index", model);
            }
            else
            {
                return View("Index", model);
            }
        }
    }

    public IActionResult Archive()
    {
        var model = _pageService.GetPages();
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return PartialView("Archive", model);
        }
        return View(model);
    }
    //moqe ajax vaqti tedad vorodi az 1 balatare hatman bayad route bdi ke beshnase
    //vagarna be khata mikhore o nemishnase makhsosan az jense int nabashe
    //[Route("Group/{id}/{title}")]
    //bdoone route ham ok kardam faqat bayad daqiq url ra moshakhas koni
    public IActionResult ShowNewsById(int id,string title)
    {
        ViewBag.Name = title;
        var model = _pageService.GetPagesById(id);
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return PartialView("ShowNewsById", model);
        }
        return View(model);
    }
    public IActionResult ShowNews(int id)
    {
        var model = _pageService.GetPageById(id);
        if (model == null)
        {
            return NotFound();
        }
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return PartialView("ShowNews", model);
        }
        return View(model);
    }
    [HttpPost]
    public IActionResult AddComment(int pageId, string name, string email, string comment)
    {
        _pageCommentService.Insert(pageId, name, email, comment);
        var model = _pageService.GetPageById(pageId);
        return PartialView("~/Views/Home/_sectionCommentForNews.cshtml", model);
        //return Ok();
    }
}
