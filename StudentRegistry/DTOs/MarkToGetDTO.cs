namespace StudentRegistry.DTOs
{
    public class MarkToGetDTO
    {
        public int Value { get; set; }  // The mark given, e.g., 8 out of 10.
        public DateTime DateGiven { get; set; }  // The date and time the mark was awarded.
        public string CourseName { get; set; }  // The name of the course associated with the mark.
    }
}
