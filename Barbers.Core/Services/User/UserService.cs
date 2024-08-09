using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Data.Context;
using Barbers.Core.DTOs;
using TopLearn.Core.Security;

namespace Barbers.Core.Services.User
{
    public class UserService : IUserService
    {
        private BarbersContext _context;

        public UserService(BarbersContext context)
        {
            _context = context;
        }


        public int AddUSer(Barber.Data.Entities.User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.userId;
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string username)
        {
            return _context.Users.Any(u=>u.UserName == username);
        }

        public Barber.Data.Entities.User LoginUser(LoginViewModel login)
        {
            string hashpass = PasswordHelper.EncodePasswordMd5(login.password);
            return _context.Users.SingleOrDefault(u => u.UserName == login.UserName && u.password == hashpass);
        }

        public void ChangePassword(string email, string newpassword)
        {
            var user = GetuserByEmail(email);
            user.password = PasswordHelper.EncodePasswordMd5(newpassword); 
            UpdateUser(user);
            

        }

        public bool ComparePassword(string oldpassword, string username)
        {
            string HashOldpassword = PasswordHelper.EncodePasswordMd5(oldpassword);
            return _context.Users.Any(u => u.UserName == username && u.password == HashOldpassword);
        }

        public Barber.Data.Entities.User GetuserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u=>u.Email == email);
        }

        public void UpdateUser(Barber.Data.Entities.User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public Barber.Data.Entities.User GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public InfomationUserViewModel getInformationUser(string username)
        {
            var user = GetUserByUserName(username);

            InfomationUserViewModel model = new InfomationUserViewModel();
            model.Email = user.Email;
            model.UserName = user.UserName;
            model.Joindate = user.JoinDate;
            return model;
        }

        public EditeProfileUserViewModel GetDataForEdite(string username)
        {
            return _context.Users.Where(u=>u.UserName == username)
                .Select(e=> new EditeProfileUserViewModel
                {
                    UserName = e.UserName,
                    Email = e.Email,
                    FullName = e.FullName,
                    Phone = e.Phone
                }).Single();
        }

        public void EditeProfile(EditeProfileUserViewModel model, string username)
        {
            var user = GetUserByUserName(username);
            user.UserName = model.UserName;
            user.Email= model.Email;
            user.FullName = model.FullName;
            user.Phone = model.Phone;
            UpdateUser(user);
        }
    }
}
