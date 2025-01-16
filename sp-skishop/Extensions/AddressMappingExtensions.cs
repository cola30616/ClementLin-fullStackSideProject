using Core.Entities;
using sp_skishop.DTOs;

namespace sp_skishop.Extensions
{
    public static class AddressMappingExtensions
    {
        // 這邊是用Mapping 各種extensions(主要是不想用automapper ，先自己寫)
      
        public static AddressDto ToDto(this Address? address)
        {
            if(address == null) return null;

            return new AddressDto
            {
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                State = address.State,
                Country = address.Country,
                PostalCode = address.PostalCode,
            };
        }

        public static Address ToEntity(this AddressDto addressDto)
        {
            if (addressDto == null) throw new ArgumentNullException("address");

            return new Address
            {
                Line1 = addressDto.Line1,
                Line2 = addressDto.Line2,
                City = addressDto.City,
                State = addressDto.State,
                Country = addressDto.Country,
                PostalCode = addressDto.PostalCode,
            };
        }

        public static void UpdateFromDto(this Address address, AddressDto addressDto)
        {
            if (addressDto == null) throw new ArgumentNullException(nameof(address));
            if (address == null) throw new ArgumentNullException(nameof(addressDto));

            address.Line1 = addressDto.Line1;
            address.Line2 = addressDto.Line2;
            address.City = addressDto.City;
            address.State = addressDto.State;
            address.Country = addressDto.Country;
            address.PostalCode = addressDto.PostalCode;
           
        }
    }


}
