using Barber.Data.Context;
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
    }
}
