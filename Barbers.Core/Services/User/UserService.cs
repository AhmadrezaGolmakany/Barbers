using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Data.Context;
using Barber.Data.Entities.User;
using Barber.Data.Entities.Wallet;
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


        public int AddUSer(Barber.Data.Entities.User.User user)
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

        public Barber.Data.Entities.User.User LoginUser(LoginViewModel login)
        {
            string hashpass = PasswordHelper.EncodePasswordMd5(login.password);
            return _context.Users.SingleOrDefault(u => u.UserName == login.UserName && u.password == hashpass);
        }

        public int GetUserIdByUsername(string username)
        {
            return _context.Users.Single(u => u.UserName == username).userId;
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

        public int BalanceWallet(string username)
        {
            int userId = GetUserIdByUsername(username);

            var enter = _context.Wallets
                .Where(w => w.userId == userId && w.TypeId == 1)
                .Select(w => w.Amount).ToList();

            var exist = _context.Wallets
                .Where(w => w.userId == userId && w.TypeId == 2)
                .Select(w => w.Amount).ToList();

            return (enter.Sum() - exist.Sum());
        }

        public List<WalletViewModel> GetUserWallet(string username)
        {
            int userId = GetUserIdByUsername(username);
            return _context.Wallets
                .Where(w => w.IsPay == true && w.userId == userId)
                .Select(w => new WalletViewModel()
                {
                    Amount = w.Amount,
                    Type = w.TypeId,
                    Description = w.Description,
                    dateTime = w.CreateDate

                }).ToList();
        }

        public int ChargeWallet(string username, string description, int amount, bool ispay = false)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                Description = description,
                IsPay = ispay,
                TypeId = 1,
                userId = GetUserIdByUsername(username)
            };
            return AddWallet(wallet);

        }

        public int AddWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet.WalletId;
        }

        public Wallet GetWalletByWalletId(int walletId)
        {
            return _context.Wallets.Find(walletId);
        }

        public void UpdateWallet(Wallet wallet)
        {
            _context.Update(wallet);
            _context.SaveChanges();
        }

        public UserForAdminViewModel getSUserForAdmin(int pageId = 1, string filteremail = "", string filterusername = "")
        {
            IQueryable<Barber.Data.Entities.User.User> result = _context.Users;

            if (!string.IsNullOrEmpty(filterusername))
            {
                result = result.Where(u => u.UserName.Contains(filterusername));
            }

            if (!string.IsNullOrEmpty(filteremail))
            {
                result = result.Where(u => u.Email.Contains(filteremail));
            }

            int take = 20;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();

            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;

            list.users = result.OrderBy(r => r.UserName).Skip(skip).Take(take).ToList();

            return list;
        }

        public int AddUserForAdmin(CreateUserForAdmin create)
        {
            Barber.Data.Entities.User.User user = new Barber.Data.Entities.User.User();
            user.UserName = create.UserName;
            user.Email = create.Email;
            user.password = PasswordHelper.EncodePasswordMd5(create.Password);
            user.Phone = create.Phone;
            user.FullName = create.FullName;
            user.JoinDate = DateTime.Now;
           


            return AddUSer(user);
        }

        public EditeUserFromAdminViewModel getUserForEdite(int userId)
        {
           return _context.Users.Where(u => u.userId == userId)
                .Select(u=> new EditeUserFromAdminViewModel()
                {
                    UserId = u.userId,
                    Phone = u.Phone,
                    Email = u.Email,
                    FullName = u.FullName,
                    UserName = u.UserName,
                    UserRole = u.userRoles.Select(r=>r.RoleId).ToList()
                }).Single();

        }

        public void EditeUserFromAdmin(EditeUserFromAdminViewModel edite)
        {
            Barber.Data.Entities.User.User user = GetUserbyUserId(edite.UserId);

            if (!string.IsNullOrEmpty(edite.Password))
            {
                user.password = PasswordHelper.EncodePasswordMd5(edite.Password);
            }

            _context.Users.Update(user);
            _context.SaveChanges();

        }

        public Barber.Data.Entities.User.User GetuserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u=>u.Email == email);
        }

        public void UpdateUser(Barber.Data.Entities.User.User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public Barber.Data.Entities.User.User GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public Barber.Data.Entities.User.User GetUserbyUserId(int userId)
        {
            return _context.Users.Find(userId);
        }

        public InfomationUserViewModel getInformationUser(string username)
        {
            var user = GetUserByUserName(username);

            InfomationUserViewModel model = new InfomationUserViewModel();
            model.Email = user.Email;
            model.UserName = user.UserName;
            model.Joindate = user.JoinDate;
            model.Wallet = BalanceWallet(username);
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
