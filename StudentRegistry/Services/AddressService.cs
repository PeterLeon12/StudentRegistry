using StudentRegistry.Data;
using StudentRegistry.DTOs;
using StudentRegistry.Extensions;
using StudentRegistry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace StudentRegistry.Services
{
    public class AddressService
    {
        private readonly StudentRegistryDbContext _context;

        public AddressService(StudentRegistryDbContext context)
        {
            _context = context;
        }

        public async Task<AddressDTO> GetAddressByStudentIdAsync(Guid studentId)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.StudentId == studentId);
            return address?.ToAddressDTO();
        }

        public async Task<AddressDTO> CreateOrUpdateAddressAsync(Guid studentId, AddressDTO addressDto)
        {
            var student = await _context.Students.Include(s => s.Address).FirstOrDefaultAsync(s => s.Id == studentId);
            if (student == null) return null;

            if (student.Address == null)
            {
                student.Address = addressDto.ToAddress();
                student.Address.StudentId = studentId;
                _context.Addresses.Add(student.Address);
            }
            else
            {
                student.Address.City = addressDto.City;
                student.Address.Street = addressDto.Street;
                student.Address.Number = addressDto.Number;
            }

            await _context.SaveChangesAsync();
            return student.Address.ToAddressDTO();
        }

        public async Task<bool> DeleteAddressAsync(Guid studentId)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.StudentId == studentId);
            if (address == null) return false;

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
