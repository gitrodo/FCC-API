using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCheck_BE.Dtos
{
    public class AddressDTO
    {
        public int Id { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string StreeType { get; set; }
        public string Apt { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
