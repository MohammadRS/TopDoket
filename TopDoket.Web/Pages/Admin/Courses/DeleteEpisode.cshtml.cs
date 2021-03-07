using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopDoket.Core.Services.Interfaces;
using TopDoket.DataLayer.Entities.Course;

namespace TopDoket.Web.Pages.Admin.Courses
{
    public class DeleteEpisodeModel : PageModel
    {
        private ICourseService _courseService;

        public DeleteEpisodeModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public CourseEpisode CourseEpisode { get; set; }
        public void OnGet(int id)
        {
            CourseEpisode = _courseService.GetEpisodeById(id);
        }

        public IActionResult OnPost()
        {
            _courseService.DeleteEpisode(CourseEpisode);

            return RedirectToPage("Index");
        }
    }
}
