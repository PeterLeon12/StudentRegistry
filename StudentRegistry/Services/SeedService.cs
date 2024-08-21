using StudentRegistry.Data;
using StudentRegistry.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistry.Services
{
    public class SeedService
    {
        private readonly StudentRegistryDbContext _context;

        public SeedService(StudentRegistryDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (await _context.Students.AnyAsync()) return;

            var students = new List<Student>
            {
                new Student { FirstName = "John", LastName = "Doe", Age = 20 },
                new Student { FirstName = "Jane", LastName = "Smith", Age = 22 },
            };

            _context.Students.AddRange(students);
            await _context.SaveChangesAsync();
        }
    }
}
