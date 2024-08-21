using StudentRegistry.Models;
using StudentRegistry.DTOs;

namespace StudentRegistry.Extensions
{
    public static class AddressExtensions
    {
        public static AddressDTO ToAddressDTO(this Address address)
        {
            return new AddressDTO
            {
                City = address.City,
                Street = address.Street,
                Number = address.Number
            };
        }

        public static Address ToAddress(this AddressDTO addressDto)
        {
            return new Address
            {
                City = addressDto.City,
                Street = addressDto.Street,
                Number = addressDto.Number
            };
        }
    }
}
