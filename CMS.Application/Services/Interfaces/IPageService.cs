using CMS.Domain.Dtoes.Page;
using CMS.Domain.Dtoes.PageGroup;
using CMS.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Interfaces
{
    public interface IPageService
    {
        PageViewModel GetPages();
        void Insert(CreatePageDto create);
        DetailPageDto GetPage(int id);
        EditPageDto GetPageForEdit(int id);
        void Update(EditPageDto edit);
        DeletePageDto GetPageForDelete(int id);
        void Delete(DeletePageDto delete);
        PageViewModel TopNews();
        PageViewModel Slider();
        PageViewModel LastNews(int take = 4);
        PageViewModel GetPagesById(int id);
        PageViewModel GetPageById(int id);
        PageViewModel Search(string para);
    }
}
