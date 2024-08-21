using Microsoft.AspNetCore.Mvc;
using StudentRegistry.Services;
using StudentRegistry.DTOs;
using System;
using System.Threading.Tasks;

namespace StudentRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly MarkService _markService;

        public MarksController(MarkService markService)
        {
            _markService = markService;
        }

        [HttpGet("student/{studentId:guid}")]
        public async Task<IActionResult> GetMarksByStudentId(Guid studentId)
        {
            var marks = await _markService.GetMarksByStudentIdAsync(studentId);
            return Ok(marks);
        }

        [HttpGet("student/{studentId:guid}/course/{courseId:guid}")]
        public async Task<IActionResult> GetMarksByStudentAndCourse(Guid studentId, Guid courseId)
        {
            var marks = await _markService.GetMarksByStudentAndCourseAsync(studentId, courseId);
            return Ok(marks);
        }

        [HttpPost]
        public async Task<IActionResult> AddMark(Guid studentId, Guid courseId, int value)
        {
            var addedMark = await _markService.AddMarkAsync(studentId, courseId, value);
            return Created("", addedMark); // Simplified response for demo purposes.
        }
    }
}
