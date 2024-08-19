using Barbers.Core.Security;
using Barbers.Core.Services.Premition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Role
{
    [PermitionChecker(5)]

    public class IndexModel : PageModel
    {
        private readonly IPremitionService _premitionService;

        public IndexModel(IPremitionService premitionService)
        {
            _premitionService = premitionService;
        }

        public List<Barber.Data.Entities.User.Role> Roles { get; set; }

        public void OnGet()
        {
            Roles = _premitionService.GetAllRoles();
        }
    }
}
