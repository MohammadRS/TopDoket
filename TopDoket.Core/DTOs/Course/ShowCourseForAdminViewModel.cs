using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDoket.Core.DTOs.Course
{
    public class ShowCourseForAdminViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int EpisodeCount { get; set; }

    }
}
