namespace StudentRegistry.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
