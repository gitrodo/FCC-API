using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCheck_BE.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string StreeType { get; set; }
        public string Apt { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
