using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
