using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Barbers.Web.Pages.Admin.Role
{
    public class IndexModel : PageModel
    {

        public List<Barber.Data.Entities.User.Role> Roles { get; set; }

        public void OnGet()
        {
        }
    }
}
