using Microsoft.AspNetCore.Mvc;
using StudentRegistry.Services;
using StudentRegistry.DTOs;
using System;
using System.Threading.Tasks;

namespace StudentRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CoursesController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseToCreateDTO courseDto)
        {
            var createdCourse = await _courseService.CreateCourseAsync(courseDto);
            return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.Id }, createdCourse); // Now using CourseToGetDTO
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCourse(Guid id, CourseToCreateDTO courseDto)
        {
            var updatedCourse = await _courseService.UpdateCourseAsync(id, courseDto);
            if (updatedCourse == null) return NotFound();
            return Ok(updatedCourse);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var isDeleted = await _courseService.DeleteCourseAsync(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }
    }
}
