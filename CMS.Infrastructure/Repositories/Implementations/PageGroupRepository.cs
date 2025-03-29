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
    public class PageGroupRepository : IPageGroupRepository
    {
        private readonly MyContext _context;
        public PageGroupRepository(MyContext context)
        {
            _context = context;
        }

        public void Delete(PageGroup pageGroup)
        {
            _context.PageGroups.Remove(pageGroup);
        }

        public PageGroup? GetPageGroupById(int id)
        {
            return _context.PageGroups.FirstOrDefault(x => x.GroupId == id);
        }

        public PageGroupViewModel GetPageGroups()
        {
            var data = _context.PageGroups.ToList();
            return new PageGroupViewModel
            {
                pageGroupList = data
            };
        }

        public IList<PageGroup> GetPageGroupsForComponents()
        {
            return _context.PageGroups.Include(x => x.pages).ToList();
        }

        public void Insert(PageGroup pageGroup)
        {
            _context.PageGroups.Add(pageGroup);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(PageGroup pageGroup)
        {
            _context.PageGroups.Update(pageGroup);
        }
    }
}
