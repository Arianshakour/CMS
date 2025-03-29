using CMS.Domain.Dtoes.PageGroup;
using CMS.Domain.ViewModels;
using CMS.Domain.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Interfaces
{
    public interface IPageGroupService
    {
        PageGroupViewModel GetPageGroups();
        void Insert(CreatePageGroupDto create);
        DetailPageGroupDto GetPageGroup(int id);
        EditPageGroupDto GetPageGroupForEdit(int id);
        void Update(EditPageGroupDto edit);
        DeletePageGroupDto GetPageGroupForDelete(int id);
        void Delete(DeletePageGroupDto delete);
        IList<ShowGroupsViewModel> GetPageGroupsForComponents();

    }
}
