using CMS.Application.Services.Interfaces;
using CMS.Domain.Dtoes.Page;
using CMS.Domain.Entities;
using CMS.Domain.ViewModels;
using CMS.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CMS.Application.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;
        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public void Delete(DeletePageDto delete)
        {
            var page = _pageRepository.GetPageById(delete.PageId);
            _pageRepository.Delete(page);
            _pageRepository.Save();
        }

        public DeletePageDto GetPageForDelete(int id)
        {
            var page = _pageRepository.GetPageById(id);
            return new DeletePageDto
            {
                PageId = page.PageId,
                Title = page.Title,
                ImageName = page.ImageName,
                GroupTitle = page.pagegroup.GroupTitle,
                PageGroupId = page.PageGroupId
            };
        }

        public EditPageDto GetPageForEdit(int id)
        {
            var page = _pageRepository.GetPageById(id);
            return new EditPageDto
            {
                PageId = page.PageId,
                PageGroupId = page.PageGroupId,
                Title = page.Title,
                Text = page.Text,
                ShortDescription = page.ShortDescription,
                ShowInSlider = page.ShowInSlider,
                ImageName = page.ImageName,
                Tags = page.Tags
            };
        }
        public void Update(EditPageDto edit)
        {
            var page = _pageRepository.GetPageById(edit.PageId);
            page.PageGroupId = edit.PageGroupId;
            page.Title = edit.Title;
            page.Text = edit.Text;
            page.ShortDescription = edit.ShortDescription;
            page.ShowInSlider = edit.ShowInSlider;
            page.ImageName = edit.ImageName;
            page.Tags = edit.Tags;
            _pageRepository.Update(page);
            _pageRepository.Save();
        }

        public DetailPageDto GetPage(int id)
        {
            var page = _pageRepository.GetPageById(id);
            return new DetailPageDto
            {
                PageGroupId = page.PageGroupId,
                Title = page.Title,
                Text = page.Text,
                ShortDescription = page.ShortDescription,
                ShowInSlider = page.ShowInSlider,
                ImageName = page.ImageName,
                CreateDate = page.CreateDate,
                GroupTitle = page.pagegroup.GroupTitle
            };
        }

        public PageViewModel GetPages()
        {
            return _pageRepository.GetPages();
        }

        public void Insert(CreatePageDto create)
        {
            var page = new Page()
            {
                PageGroupId = create.PageGroupId,
                Title = create.Title,
                Text = create.Text,
                CreateDate = DateTime.Now,
                ShortDescription = create.ShortDescription,
                ShowInSlider = create.ShowInSlider,
                ImageName = create.ImageName,
                Tags = create.Tags,
                Visit = 0
            };
            _pageRepository.Insert(page);
            _pageRepository.Save();
        }

        public PageViewModel TopNews()
        {
            return _pageRepository.TopNews();
        }

        public PageViewModel Slider()
        {
            return _pageRepository.Slider();
        }

        public PageViewModel LastNews(int take = 4)
        {
            return _pageRepository.LastNews();
        }

        public PageViewModel GetPagesById(int id)
        {
            return _pageRepository.GetPagesById(id);
        }

        public PageViewModel GetPageById(int id)
        {
            var data = _pageRepository.GetPageById(id);
            data.Visit += 1;
            _pageRepository.Update(data);
            _pageRepository.Save();
            data.PageComments = data.PageComments.Where(x => x.IsShow == true).ToList();
            return new PageViewModel
            {
                page = data
            };
        }

        public PageViewModel Search(string para)
        {
            return _pageRepository.Search(para);
        }
    }
}
