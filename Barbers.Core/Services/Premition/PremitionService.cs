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
    }
}
