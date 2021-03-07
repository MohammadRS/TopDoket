using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopDoket.Core.DTOs;
using TopDoket.Core.Services.Interfaces;

namespace TopDoket.Web.Pages.Admin.Users
{
    public class ActivateUserModel : PageModel
    {
        private IUserService _userService;

        public ActivateUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public InformationUserViewModel InformationUserViewModel { get; set; }
        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            //ViewData["UserId"] = _userService.ActivateUser(id);
            InformationUserViewModel = _userService.GetUserInformation(id);
        }

        public IActionResult OnPost(int UserId)
        {
            InformationUserViewModel = _userService.GetUserInformation(UserId);
            _userService.ActivateUser(UserId);
            return RedirectToPage("Index");
        }
    }
}
