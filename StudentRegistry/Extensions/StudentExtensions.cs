using StudentRegistry.Models;
using StudentRegistry.DTOs;

namespace StudentRegistry.Extensions
{
    public static class StudentExtensions
    {
        public static StudentToGetDTO ToStudentGetDTO(this Student student)
        {
            return new StudentToGetDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age
            };
        }
    }
}
