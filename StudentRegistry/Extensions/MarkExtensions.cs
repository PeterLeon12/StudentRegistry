using StudentRegistry.Models;
using StudentRegistry.DTOs;

namespace StudentRegistry.Extensions
{
    public static class MarkExtensions
    {
        public static MarkToGetDTO ToMarkToGetDTO(this Mark mark)
        {
            return new MarkToGetDTO
            {
                Value = mark.Value,
                DateGiven = mark.DateGiven,
                CourseName = mark.Course?.Name // Include the course name
            };
        }
    }
}
