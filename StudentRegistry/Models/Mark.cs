using System;

namespace StudentRegistry.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public DateTime DateGiven { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
