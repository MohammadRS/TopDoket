using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDoket.DataLayer.Entities.Course;

namespace TopDoket.Core.DTOs.Course
{
    public class ShowCourseListItemViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int Price { get; set; }
        public List<CourseEpisode> CourseEpisodes { get; set; }

    }
}
