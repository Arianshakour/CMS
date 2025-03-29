using CMS.Application.Services.Interfaces;
using CMS.Domain.Dtoes.PageGroup;
using CMS.Domain.Entities;
using CMS.Domain.ViewModels;
using CMS.Domain.ViewModels.Components;
using CMS.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Implementations
{
    public class PageGroupService : IPageGroupService
    {
        private readonly IPageGroupRepository _pageGroupRepository;
        public PageGroupService(IPageGroupRepository pageGroupRepository)
        {
            _pageGroupRepository = pageGroupRepository;
        }

        public void Delete(DeletePageGroupDto delete)
        {
            var pageGroup = _pageGroupRepository.GetPageGroupById(delete.GroupId);
            _pageGroupRepository.Delete(pageGroup);
            _pageGroupRepository.Save();
        }
        public DeletePageGroupDto GetPageGroupForDelete(int id)
        {
            var pageGroup = _pageGroupRepository.GetPageGroupById(id);
            return new DeletePageGroupDto
            {
                GroupId = pageGroup.GroupId,
                GroupTitle = pageGroup.GroupTitle
            };
        }
        public DetailPageGroupDto GetPageGroup(int id)
        {
            var pageGroup = _pageGroupRepository.GetPageGroupById(id);
            return new DetailPageGroupDto
            {
                GroupTitle = pageGroup.GroupTitle
            };
        }
        public EditPageGroupDto GetPageGroupForEdit(int id)
        {
            var pageGroup = _pageGroupRepository.GetPageGroupById(id);
            return new EditPageGroupDto
            {
                GroupId = pageGroup.GroupId,
                GroupTitle = pageGroup.GroupTitle
            };
        }
        public void Update(EditPageGroupDto edit)
        {
            var pageGroup = _pageGroupRepository.GetPageGroupById(edit.GroupId);
            pageGroup.GroupTitle = edit.GroupTitle;
            _pageGroupRepository.Update(pageGroup);
            _pageGroupRepository.Save();
        }

        public PageGroupViewModel GetPageGroups()
        {
            return _pageGroupRepository.GetPageGroups();
        }

        public void Insert(CreatePageGroupDto create)
        {
            var pageGroup = new PageGroup()
            {
                GroupTitle = create.GroupTitle
            };
            _pageGroupRepository.Insert(pageGroup);
            _pageGroupRepository.Save();
        }

        public IList<ShowGroupsViewModel> GetPageGroupsForComponents()
        {
            var model = _pageGroupRepository.GetPageGroupsForComponents();
            return model.Select(x => new ShowGroupsViewModel
            {
                GroupId = x.GroupId,
                GroupTitle = x.GroupTitle,
                PageCount = x.pages.Count
            }).ToList();
        }
    }
}
