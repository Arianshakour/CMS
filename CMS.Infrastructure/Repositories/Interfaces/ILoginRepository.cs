using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        bool IsExistUser(string userName);
        bool IsExistEmail(string email);
        void AddUser(Member member);
        Member? GetMember(string email, string pass);
        void Save();
        Member? GetMemberByEmail(string email);
        void Update(Member member);
    }
}
