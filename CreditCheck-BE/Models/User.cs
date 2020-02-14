using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCheck_BE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string EmailAddress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Pin { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<ScoreQuery> ScoreQueries { get; set; }
    }
}
