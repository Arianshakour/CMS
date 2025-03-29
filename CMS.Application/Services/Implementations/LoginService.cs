using CMS.Application.Services.Interfaces;
using CMS.Domain.Common;
using CMS.Domain.Dtoes.Member;
using CMS.Domain.Entities;
using CMS.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public void AddUser(RegisterDto register)
        {
            var member = new Member()
            {
                Email = FixedText.FixedEmail(register.Email),
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                ActiveCode = NameGenerator.GenerateUniqCode(),
                IsActive = false,
                BrithDay = DateTime.Now,
                UserName = register.UserName
            };
            _loginRepository.AddUser(member);
            _loginRepository.Save();
        }

        public ChangePassDto ChangePass(string email)
        {
            return new ChangePassDto()
            {
                Email = email
            };
        }

        public Member? GetMember(LoginDto login)
        {
            string email = FixedText.FixedEmail(login.Email);
            string pass = PasswordHelper.EncodePasswordMd5(login.Password);
            var member = _loginRepository.GetMember(email, pass);
            if (member == null)
            {
                return null;
            }
            return member;
        }

        public bool IsCorrectPassword(string email, string pass)
        {
            var member = _loginRepository.GetMemberByEmail(email);
            var passtohash = PasswordHelper.EncodePasswordMd5(pass);
            return passtohash == member.Password;
        }

        public bool IsExistEmail(string email)
        {
            var x = FixedText.FixedEmail(email);
            return _loginRepository.IsExistEmail(x);
        }

        public bool IsExistUser(string userName)
        {
            return _loginRepository.IsExistUser(userName);
        }

        public void UpdatePass(ChangePassDto change)
        {
            var member = _loginRepository.GetMemberByEmail(change.Email);
            member.Password = PasswordHelper.EncodePasswordMd5(change.NewPassword);
            _loginRepository.Update(member);
            _loginRepository.Save();
        }
    }
}
