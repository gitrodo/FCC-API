using CreditCheck_BE.Models;
using System.Threading.Tasks;

namespace CreditCheck_BE.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> ValidateUser(string username, string email);
    }
}
