using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbers.Core.Services.User
{
    public interface IUserService
    {
        int AddUSer(Barber.Data.Entities.User user);
    }
}
