using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barbers.Core.DTOs;

namespace Barbers.Core.Services.User
{
    public interface IUserService
    {
        int AddUSer(Barber.Data.Entities.User user);

        bool IsExistEmail(string email);

        bool IsExistUserName(string username);


        Barber.Data.Entities.User LoginUser(LoginViewModel login);

        void ChangePassword(string email, string newpassword);

        bool ComparePassword(string oldpassword, string username);


        Barber.Data.Entities.User GetuserByEmail(string email);

        void UpdateUser(Barber.Data.Entities.User user);

        Barber.Data.Entities.User GetUserByUserName(string username);





        #region UserPanel

        InfomationUserViewModel getInformationUser( string username );

        #endregion


    }
}
