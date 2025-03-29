using CMS.Domain.Entities;
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
    public class PageCommentRepository : IPageCommentRepository
    {
        private readonly MyContext _context;
        public PageCommentRepository(MyContext context)
        {
            _context = context;
        }

        public void Delete(PageComment comment)
        {
            _context.PageComments.Remove(comment);
        }

        public PageComment? GetPageCommentById(int id)
        {
            return _context.PageComments.Include(p=>p.page).Include(x=>x.page.pagegroup).FirstOrDefault(x => x.CommentId == id);
        }

        public IList<PageComment> GetPageComments(int id)
        {
            return _context.PageComments.Include(p => p.page).Include(x => x.page.pagegroup).Where(x => x.PageId == id).ToList();
        }

        public void Insert(PageComment comment)
        {
            _context.PageComments.Add(comment);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(PageComment comment)
        {
            _context.PageComments.Update(comment);
        }
    }
}
