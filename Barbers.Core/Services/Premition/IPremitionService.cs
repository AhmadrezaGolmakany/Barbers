using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Data.Entities.User;

namespace Barbers.Core.Services.Premition
{
    public interface IPremitionService
    {

        #region Role

        List<Role> GetAllRoles();

        void AddRoleUser(List<int> RoleId, int userId);


        void EditeUserRole(int userId , List<int> RoleId);

        int AddRoel(Role role);


        Role GetRoleByRoleId(int roleId);
        void UpdateRole(Role role);

        void DeleteRole(Role role);

        #endregion


        #region Premition

       List<Barber.Data.Entities.Premition.Premitions> GetAllPremitions();

        void AddPremition(int roleId , List<int> selectedpremition);

        List<int> PermissionRoles(int roleId);

        void UpdatePemissions(int roleId , List<int> premition);


        bool CheckPermission(int permissionId, string userName);

   


        #endregion
    }
}
