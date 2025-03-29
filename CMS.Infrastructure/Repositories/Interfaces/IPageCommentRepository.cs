using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories.Interfaces
{
    public interface IPageCommentRepository
    {
        void Insert(PageComment comment);
        IList<PageComment> GetPageComments(int id);
        void Save();
        void Update(PageComment comment);
        void Delete(PageComment comment);
        PageComment? GetPageCommentById(int id);
    }
}
