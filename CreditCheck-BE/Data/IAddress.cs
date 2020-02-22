using CreditCheck_BE.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCheck_BE.Data
{
    public interface IAddress<T>
    {
        Task<List<T>> SearchAddress(AddressDTO addressDTO);
    }
}
