using CreditCheck_BE.Dtos;
using CreditCheck_BE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCheck_BE.Data
{
    public class AddressRepository : IAddress<AddressDTO>
    {
        public DataContext _dataContext { get; set; }
        public AddressRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        public async Task<List<AddressDTO>> SearchAddress(AddressDTO addressDTO)
        {
            var collection = await _dataContext.Addresses.Where(
                p => p.ZipCode.Contains(addressDTO.ZipCode) || 
                (p.HouseNumber == addressDTO.HouseNumber && p.StreetName == addressDTO.StreetName))
                .ToListAsync();



            List<AddressDTO> addressList = new List<AddressDTO>();
            foreach (var item in collection)
            {
                addressList.Add(new AddressDTO
                {
                    HouseNumber = item.HouseNumber,
                    StreetName = item.StreetName,
                    StreeType = item.StreeType,
                    Apt = item.Apt,
                    City = item.City,
                    State = item.State,
                    ZipCode = item.ZipCode
                });
            }

            if (collection.Count() == 0)
                return null;

            return addressList;
        }
    }
}
