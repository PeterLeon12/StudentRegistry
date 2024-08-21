using StudentRegistry.Data;
using StudentRegistry.DTOs;
using StudentRegistry.Extensions;
using StudentRegistry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRegistry.Services
{
    public class MarkService
    {
        private readonly StudentRegistryDbContext _context;

        public MarkService(StudentRegistryDbContext context)
        {
            _context = context;
        }

        public async Task<List<MarkToGetDTO>> GetMarksByStudentIdAsync(Guid studentId)
        {
            return await _context.Marks
                .Include(m => m.Course)
                .Where(m => m.StudentId == studentId)
                .Select(m => m.ToMarkToGetDTO())
                .ToListAsync();
        }

        public async Task<List<MarkToGetDTO>> GetMarksByStudentAndCourseAsync(Guid studentId, Guid courseId)
        {
            return await _context.Marks
                .Include(m => m.Course)
                .Where(m => m.StudentId == studentId && m.CourseId == courseId)
                .Select(m => m.ToMarkToGetDTO())
                .ToListAsync();
        }

        public async Task<MarkToGetDTO> AddMarkAsync(Guid studentId, Guid courseId, int value)
        {
            var mark = new Mark
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                CourseId = courseId,
                Value = value,
                DateGiven = DateTime.Now
            };

            _context.Marks.Add(mark);
            await _context.SaveChangesAsync();
            return mark.ToMarkToGetDTO();
        }
    }
}
