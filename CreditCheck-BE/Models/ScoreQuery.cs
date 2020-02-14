using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCheck_BE.Models
{
    public class ScoreQuery
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public char StreetType { get; set; }
        public int AptNumber { get; set; }
        public string City { get; set; }
        public char State { get; set; }
        public string Zip { get; set; }
        public int SocialNumber { get; set; }
        public bool IsCurrentLocation { get; set; }
    }
}
