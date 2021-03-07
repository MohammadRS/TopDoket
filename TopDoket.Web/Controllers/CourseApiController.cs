using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopDoket.DataLayer.Context;

namespace TopDoket.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApiController : ControllerBase
    {
        private TopContext _context;

        public CourseApiController(TopContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var courseTitle = _context.Courses
                    .Where(c => c.CourseTitle.Contains(term))
                    .Select(c => c.CourseTitle)
                    .ToList();
                return Ok(courseTitle);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
