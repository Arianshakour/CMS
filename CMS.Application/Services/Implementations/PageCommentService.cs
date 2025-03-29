using CMS.Application.Services.Interfaces;
using CMS.Domain.Dtoes.PageComment;
using CMS.Domain.Entities;
using CMS.Domain.ViewModels;
using CMS.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Implementations
{
    public class PageCommentService : IPageCommentService
    {
        private readonly IPageCommentRepository _pageCommentRepository;
        public PageCommentService(IPageCommentRepository pageCommentRepository)
        {
            _pageCommentRepository = pageCommentRepository;
        }

        public void Delete(DeletePageCommentDto delete)
        {
            var x = _pageCommentRepository.GetPageCommentById(delete.CommentId);
            _pageCommentRepository.Delete(x);
            _pageCommentRepository.Save();
        }

        public DetailPageCommentDto GetById(int id)
        {
            var x = _pageCommentRepository.GetPageCommentById(id);
            return new DetailPageCommentDto
            {
                CommentId = x.CommentId,
                Comment = x.Comment,
                Name = x.Name,
                Email = x.Email,
                IsShow = x.IsShow,
                PageName = x.page.Title,
                GroupName = x.page.pagegroup.GroupTitle,
                PageId = x.PageId
            };
        }

        public DeletePageCommentDto GetByIdForDelete(int id)
        {
            var x = _pageCommentRepository.GetPageCommentById(id);
            return new DeletePageCommentDto
            {
                CommentId = x.CommentId,
                Comment = x.Comment,
                Name = x.Name,
                Email = x.Email,
                IsShow = x.IsShow,
                PageName = x.page.Title,
                GroupName = x.page.pagegroup.GroupTitle,
                PageId = x.PageId
            };
        }

        public EditPageCommentDto GetByIdForEdit(int id)
        {
            var x = _pageCommentRepository.GetPageCommentById(id);
            return new EditPageCommentDto
            {
                CommentId = x.CommentId,
                Comment = x.Comment,
                Name = x.Name,
                Email = x.Email,
                IsShow = x.IsShow,
                PageName = x.page.Title,
                GroupName = x.page.pagegroup.GroupTitle,
                PageId = x.PageId
            };
        }
        public void Update(EditPageCommentDto edit)
        {
            var x = _pageCommentRepository.GetPageCommentById(edit.CommentId);
            x.Comment = edit.Comment;
            x.IsShow = edit.IsShow;
            x.Name = edit.Name;
            x.Email = edit.Email;
            _pageCommentRepository.Update(x);
            _pageCommentRepository.Save();
        }

        public PageCommentViewModel GetPageCommentsByPageId(int id)
        {
            var data = _pageCommentRepository.GetPageComments(id);
            return new PageCommentViewModel
            {
                pageCommentList = data.ToList() 
            };
        }

        public void Insert(int pageId, string name, string email, string comment)
        {
            PageComment cmt = new PageComment()
            {
                PageId = pageId,
                Name = name,
                Email = email,
                Comment = comment,
                CreateDate = DateTime.Now,
                IsShow = false
            };
            _pageCommentRepository.Insert(cmt);
            _pageCommentRepository.Save();
        }

        
    }
}
