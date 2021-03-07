using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopDoket.DataLayer.Entities.Course
{
   public class CourseStatus
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(150)]
        public string StatusTitle { get; set; }

        public List<Course> Courses { get; set; }

    }
}
