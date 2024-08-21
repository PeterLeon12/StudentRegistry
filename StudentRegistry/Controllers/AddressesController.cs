using Microsoft.AspNetCore.Mvc;
using StudentRegistry.Services;
using StudentRegistry.DTOs;
using System;
using System.Threading.Tasks;

namespace StudentRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressesController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{studentId:guid}")]
        public async Task<IActionResult> GetAddressByStudentId(Guid studentId)
        {
            var address = await _addressService.GetAddressByStudentIdAsync(studentId);
            if (address == null) return NotFound();
            return Ok(address);
        }

        [HttpPost("{studentId:guid}")]
        public async Task<IActionResult> CreateOrUpdateAddress(Guid studentId, AddressDTO addressDto)
        {
            var updatedAddress = await _addressService.CreateOrUpdateAddressAsync(studentId, addressDto);
            if (updatedAddress == null) return BadRequest("Unable to create or update address.");
            return Ok(updatedAddress);
        }

        [HttpDelete("{studentId:guid}")]
        public async Task<IActionResult> DeleteAddress(Guid studentId)
        {
            var isDeleted = await _addressService.DeleteAddressAsync(studentId);
            if (!isDeleted) return NotFound();
            return NoContent();
        }
    }
}
