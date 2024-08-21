using StudentRegistry.Data;
using StudentRegistry.Models;
using StudentRegistry.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentRegistry.Extensions;

namespace StudentRegistry.Services
{
    public class StudentService
    {
        private readonly StudentRegistryDbContext _context;

        public StudentService(StudentRegistryDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentToGetDTO>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Address)
                .Select(s => s.ToStudentGetDTO())
                .ToListAsync();
        }

        public async Task<StudentToGetDTO> GetStudentByIdAsync(Guid id)
        {
            var student = await _context.Students
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == id);

            return student?.ToStudentGetDTO();
        }

        public async Task<StudentToGetDTO> CreateStudentAsync(StudentToCreateDTO studentDto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Age = studentDto.Age,
                Address = new Address
                {
                    Id = Guid.NewGuid(),
                    City = studentDto.Address.City,
                    Street = studentDto.Address.Street,
                    Number = studentDto.Address.Number,
                }
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student.ToStudentGetDTO();
        }

        public async Task<StudentToGetDTO> UpdateStudentAsync(Guid id, StudentToCreateDTO studentDto)
        {
            var student = await _context.Students.Include(s => s.Address).FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) return null;

            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.Age = studentDto.Age;
            student.Address.City = studentDto.Address.City;
            student.Address.Street = studentDto.Address.Street;
            student.Address.Number = studentDto.Address.Number;

            await _context.SaveChangesAsync();

            return student.ToStudentGetDTO();
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
