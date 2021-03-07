using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopDoket.Core.Services.Interfaces;
using TopDoket.DataLayer.Entities.Course;

namespace TopDoket.Web.Pages.Admin.CourseGroups
{
    public class CreateGroupModel : PageModel
    {
        private ICourseService _courseService;

        public CreateGroupModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public CourseGroup CourseGroups { get; set; }

        public void OnGet(int? id)
        {
            CourseGroups = new CourseGroup()
            {
                ParentId = id
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _courseService.AddGroup(CourseGroups);

            return RedirectToPage("Index");
        }
    }
}
