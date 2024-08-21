using StudentRegistry.Models;
using StudentRegistry.DTOs;

namespace StudentRegistry.Extensions
{
    public static class CourseExtensions
    {
        public static CourseToGetDTO ToCourseToGetDTO(this Course course)
        {
            return new CourseToGetDTO
            {
                Id = course.Id,
                Name = course.Name
            };
        }

        public static Course ToCourse(this CourseToCreateDTO courseDto)
        {
            return new Course
            {
                Name = courseDto.Name
            };
        }
    }
}
