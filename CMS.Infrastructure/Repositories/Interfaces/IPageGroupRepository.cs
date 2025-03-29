using CMS.Domain.Entities;
using CMS.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories.Interfaces
{
    public interface IPageGroupRepository
    {
        void Insert(PageGroup pageGroup);
        void Update(PageGroup pageGroup);
        void Delete(PageGroup pageGroup);
        void Save();
        PageGroup? GetPageGroupById(int id);
        PageGroupViewModel GetPageGroups();
        IList<PageGroup> GetPageGroupsForComponents();
    }
}
