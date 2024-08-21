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
    public class CourseService
    {
        private readonly StudentRegistryDbContext _context;

        public CourseService(StudentRegistryDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseToGetDTO>> GetAllCoursesAsync()
        {
            return await _context.Courses.Select(c => c.ToCourseToGetDTO()).ToListAsync();
        }

        public async Task<CourseToGetDTO> GetCourseByIdAsync(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            return course?.ToCourseToGetDTO();
        }

        public async Task<CourseToGetDTO> CreateCourseAsync(CourseToCreateDTO courseDto)
        {
            var course = courseDto.ToCourse();
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course.ToCourseToGetDTO();
        }

        public async Task<CourseToGetDTO> UpdateCourseAsync(Guid id, CourseToCreateDTO courseDto)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return null;

            course.Name = courseDto.Name;
            await _context.SaveChangesAsync();
            return course.ToCourseToGetDTO();
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
