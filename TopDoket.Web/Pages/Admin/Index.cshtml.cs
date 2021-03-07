using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopDoket.Core.Security;

namespace TopDoket.Web.Pages.Admin
{
    [PermissionChecker(1)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}