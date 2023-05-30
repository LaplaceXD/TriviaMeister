using System.Linq;
using System.Threading.Tasks;
using TriviaMeister.Models;
using Xamarin.Forms;

namespace TriviaMeister.Services
{
    public class AuthService : IAuthService
    {
        private IDataStore<User> UserStore => DependencyService.Get<IDataStore<User>>();
        private User _auth;

        public async Task<User> GetUser()
        {
            User value = null;
            
            if(_auth != null)
            {
                value = _auth = await UserStore.GetItemAsync(_auth.Id);
            }

            return await Task.FromResult(value);
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            if (_auth == null)
            {
                var users = await UserStore.GetItemsAsync();
                var user = users.Where((User u) => u.Email == email).FirstOrDefault();

                if (user != default(User) && user.Password == password)
                {
                    return await Task.FromResult(true);
                }
            }
           
            return await Task.FromResult(false);
        }

        public async Task<bool> SignOutAsync()
        {
            if(_auth != null)
            {
                _auth = null;
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}
