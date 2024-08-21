namespace StudentRegistry.DTOs
{
    public class StudentToCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public AddressDTO Address { get; set; }
    }
}
