using CMS.Domain.Entities;
using CMS.Infrastructure.Context;
using CMS.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories.Implementations
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MyContext _context;
        public LoginRepository(MyContext context)
        {
            _context = context;
        }

        public void AddUser(Member member)
        {
            _context.Members.Add(member);
        }

        public Member? GetMember(string email, string pass)
        {
            var member = _context.Members.First(x => x.Email == email && x.Password == pass);
            return member;
        }

        public Member? GetMemberByEmail(string email)
        {
            return _context.Members.FirstOrDefault(x => x.Email == email);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Members.Any(x => x.Email == email);
        }

        public bool IsExistUser(string userName)
        {
            return _context.Members.Any(x => x.UserName == userName);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Member member)
        {
            _context.Members.Update(member);
        }
    }
}
