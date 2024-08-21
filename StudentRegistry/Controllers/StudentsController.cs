using Microsoft.AspNetCore.Mvc;
using StudentRegistry.Services;
using StudentRegistry.DTOs;
using System;
using System.Threading.Tasks;

namespace StudentRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentToCreateDTO studentToCreateDto)
        {
            var createdStudent = await _studentService.CreateStudentAsync(studentToCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid id, StudentToCreateDTO studentToUpdateDto)
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(id, studentToUpdateDto);
            if (updatedStudent == null) return NotFound();
            return Ok(updatedStudent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var isDeleted = await _studentService.DeleteStudentAsync(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }
    }
}
