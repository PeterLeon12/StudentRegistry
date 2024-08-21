namespace StudentRegistry.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
