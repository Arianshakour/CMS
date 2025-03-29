using CMS.Domain.Entities;
using CMS.Domain.ViewModels;
using CMS.Infrastructure.Context;
using CMS.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories.Implementations
{
    public class PageRepository : IPageRepository
    {
        private readonly MyContext _context;
        public PageRepository(MyContext context)
        {
            _context = context;
        }

        public void Delete(Page page)
        {
            _context.Pages.Remove(page);
        }

        public Page? GetPageById(int id)
        {
            return _context.Pages.Include(x=>x.PageComments.Where(x=>x.IsShow==true)).Include(p=>p.pagegroup).FirstOrDefault(x => x.PageId == id);
        }

        public PageViewModel GetPages()
        {
            var data = _context.Pages.Include(p => p.pagegroup).ToList();
            return new PageViewModel
            {
                pageList = data
            };
        }
        public PageViewModel TopNews()
        {
            var data = _context.Pages.Include(p => p.pagegroup).OrderByDescending(x=>x.Visit).Take(4).ToList();
            return new PageViewModel
            {
                pageList = data
            };
        }

        public void Insert(Page page)
        {
            _context.Pages.Add(page);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Page page)
        {
            _context.Update(page);
        }

        public PageViewModel Slider()
        {
            var data = _context.Pages.Where(x => x.ShowInSlider == true).ToList();
            return new PageViewModel
            {
                pageList = data
            };
        }

        public PageViewModel LastNews(int take = 4)
        {
            var data = _context.Pages.OrderByDescending(x => x.CreateDate).Take(take).ToList();
            return new PageViewModel
            {
                pageList = data
            };
        }

        public PageViewModel GetPagesById(int id)
        {
            var data = _context.Pages.Where(x => x.PageGroupId == id).ToList();
            return new PageViewModel
            {
                pageList = data
            };
        }

        public PageViewModel Search(string para)
        {
            var data = _context.Pages.Where(x => x.Title.Contains(para) || x.Text.Contains(para)
                || x.ShortDescription.Contains(para) || x.Tags.Contains(para)).Distinct().ToList();
            return new PageViewModel
            {
                pageList = data
            };
        }
    }
}
