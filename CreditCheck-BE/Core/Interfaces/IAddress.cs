using CreditCheck_BE.Dtos;
using CreditCheck_BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCheck_BE.Data
{
    public interface IAddress
    {
        Task<IEnumerable<Address>> SearchAddress(AddressDTO addressDTO);
    }
}
