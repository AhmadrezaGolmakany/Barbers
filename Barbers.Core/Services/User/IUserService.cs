using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Data.Entities.Wallet;
using Barbers.Core.DTOs;

namespace Barbers.Core.Services.User
{
    public interface IUserService
    {
        #region Account

        int AddUSer(Barber.Data.Entities.User.User user);

        bool IsExistEmail(string email);

        bool IsExistUserName(string username);


        Barber.Data.Entities.User.User LoginUser(LoginViewModel login);

        int GetUserIdByUsername(string username);


        Barber.Data.Entities.User.User GetuserByEmail(string email);

        void UpdateUser(Barber.Data.Entities.User.User user);

        Barber.Data.Entities.User.User GetUserByUserName(string username);

        Barber.Data.Entities.User.User GetUserbyUserId(int userId);

        #endregion

        #region UserPanel

        InfomationUserViewModel getInformationUser( string username );
        EditeProfileUserViewModel GetDataForEdite(string username);
        void EditeProfile(EditeProfileUserViewModel model , string username);
        void ChangePassword(string email, string newpassword);

        bool ComparePassword(string oldpassword, string username);

        #endregion


        #region Wallet

        int BalanceWallet(string username);

        List<WalletViewModel> GetUserWallet(string username);
        int ChargeWallet(string username  , string description, int amount, bool ispay = false);
        int AddWallet(Wallet wallet);

        Wallet GetWalletByWalletId(int walletId);

        void UpdateWallet(Wallet wallet);



        #endregion



        #region Admin

        UserForAdminViewModel getSUserForAdmin(int pageId = 1 , string filteremail ="" , string filterusername = "" );

        int AddUserForAdmin(CreateUserForAdmin create);

        EditeUserFromAdminViewModel getUserForEdite(int userId);

        void EditeUserFromAdmin(EditeUserFromAdminViewModel edite);

        #endregion


    }
}
