using CMS.Domain.Dtoes.Member;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Interfaces
{
    public interface ILoginService
    {
        bool IsExistUser(string userName);
        bool IsExistEmail(string email);
        void AddUser(RegisterDto register);
        Member? GetMember(LoginDto login);
        ChangePassDto ChangePass(string email);
        bool IsCorrectPassword(string email, string pass);
        void UpdatePass(ChangePassDto change);
    }
}
