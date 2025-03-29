using CMS.Domain.Dtoes.PageComment;
using CMS.Domain.Entities;
using CMS.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Interfaces
{
    public interface IPageCommentService
    {
        void Insert(int pageId , string name , string email , string comment);
        DetailPageCommentDto GetById(int id);
        EditPageCommentDto GetByIdForEdit(int id);
        void Update(EditPageCommentDto edit);
        DeletePageCommentDto GetByIdForDelete(int id);
        void Delete(DeletePageCommentDto delete);
        PageCommentViewModel GetPageCommentsByPageId(int id);

    }
}
