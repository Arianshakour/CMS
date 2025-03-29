using CMS.Domain.Entities;
using CMS.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories.Interfaces
{
    public interface IPageRepository
    {
        void Insert(Page page);
        void Update(Page page);
        void Delete(Page page);
        void Save();
        Page? GetPageById(int id);
        PageViewModel GetPages();
        PageViewModel TopNews();
        PageViewModel Slider();
        PageViewModel LastNews(int take = 4);
        PageViewModel GetPagesById(int id);
        PageViewModel Search(string para);

    }
}
