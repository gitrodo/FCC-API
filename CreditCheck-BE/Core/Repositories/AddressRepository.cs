using CreditCheck_BE.Dtos;
using CreditCheck_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCheck_BE.Data
{
    public class AddressRepository : IAddress
    {
        public DataContext _dataContext { get; set; }
        public AddressRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Address>> SearchAddress(AddressDTO addressDTO)
        {
            var collection = await _dataContext.Addresses.Where(
                p => p.ZipCode.Contains(addressDTO.ZipCode) ||
                (p.HouseNumber == addressDTO.HouseNumber && p.StreetName == addressDTO.StreetName))
                .ToListAsync();

            return collection;
        }
    }
}
