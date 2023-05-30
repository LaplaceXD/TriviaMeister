using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaMeister.Models;

namespace TriviaMeister.Services
{
    class UserStore : IDataStore<User>
    {
        readonly List<User> _users;

        public UserStore()
        {
            _users = new List<User>()
            {
                new User {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "user@example.com",
                    Password = "Abcd1234!"
                },
            };
        }

        public async Task<bool> AddItemAsync(User item)
        {
            _users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var user = _users.Where((User t) => t.Id == id).FirstOrDefault();
            if (user == default(User))
            {
                return await Task.FromResult(false);
            }

            _users.Remove(user);
            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            var trivia = _users.Where((User t) => t.Id == id).FirstOrDefault();

            return await Task.FromResult(trivia);
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_users);
        }

        public async Task<bool> UpdateItemAsync(User newUser)
        {
            var oldUser = _users.Where((User t) => t.Id == newUser.Id).FirstOrDefault();
            if (oldUser == default(User))
            {
                return await Task.FromResult(false);
            }

            var index = _users.IndexOf(oldUser);

            _users.Remove(oldUser);
            _users.Insert(index, newUser);

            return await Task.FromResult(true);
        }
    }
}
