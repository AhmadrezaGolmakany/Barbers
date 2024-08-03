using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Data.Context;

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
    }
}
