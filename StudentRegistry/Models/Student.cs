using System;
using System.Collections.Generic;
using System.Net;

namespace StudentRegistry.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
