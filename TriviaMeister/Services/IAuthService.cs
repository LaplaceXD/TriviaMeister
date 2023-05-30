using System.Threading.Tasks;
using TriviaMeister.Models;

namespace TriviaMeister.Services
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string email, string password);
        Task<User> GetUser();
        Task<bool> SignOutAsync();
    }
}
