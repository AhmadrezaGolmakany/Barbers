using Barber.Data.Context;
using Barber.Data.Entities.Premition;
using Barber.Data.Entities.User;

namespace Barbers.Core.Services.Premition
{
    public class PremitionService : IPremitionService
    {
        private readonly BarbersContext _context;

        public PremitionService(BarbersContext context)
        {
            _context = context;
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public void AddRoleUser(List<int> RoleId, int userId)
        {
            foreach (var roleId in RoleId)
            {
                _context.UserRoles.Add(new UserRole
                {
                    RoleId = roleId,
                    UserId = userId,
                });
            }

            _context.SaveChanges();
        }

        public void EditeUserRole(int userId, List<int> RoleId)
        {
            _context.UserRoles.Where(r=>r.UserId == userId).ToList().ForEach(r=>_context.UserRoles.Remove(r));

            AddRoleUser(RoleId , userId );
        }

        public int AddRoel(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public Role GetRoleByRoleId(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void UpdateRole(Role role)
        {
            _context.Update(role);
            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {

            role.IsDelete = true;
            UpdateRole(role);

        }

        public List<Barber.Data.Entities.Premition.Premitions> GetAllPremitions()
        {
            return _context.premitions.ToList();
        }

        public void AddPremition(int roleId, List<int> selectedpremition)
        {
            foreach (var item in selectedpremition)
            {
                _context.rolePremitions.Add(new RolePremition
                {
                    PremitionId = item,
                    RoleId = roleId

                });
            }
            _context.SaveChanges();
        }

        public List<int> PermissionRoles(int roleId)
        {
            return _context.rolePremitions.Where(p => p.RoleId == roleId)
                 .Select(r => r.PremitionId).ToList();
        }

        

        void IPremitionService.UpdatePemissions(int roleId, List<int> premition)
        {
            _context.rolePremitions.Where(r => r.RoleId == roleId).ToList()
                .ForEach(p => _context.rolePremitions.Remove(p));
            AddPremition(roleId,premition);
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userId = _context.Users.Single(u => u.UserName == userName).userId;

            List<int> userRoles = _context.UserRoles.Where(u => u.UserId == userId)
                .Select(r => r.RoleId).ToList();

            if (!userRoles.Any())
                return false;

            List<int> RolePermission = _context.rolePremitions
                .Where(r => r.PremitionId == permissionId)
                .Select(r => r.RoleId).ToList();

            return RolePermission.Any(p => userRoles.Contains(p));

        }

       
    }
}
