using LiteDB;
using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILiteCollection<User> _users;

        public UserRepository(ILiteCollection<User> users)
        {
            this._users = users;
        }

        public async Task<User> Find(int id)
        {
            await Task.Yield();
            return this._users.FindById(id);
        }

        public async Task Update(User user)
        {
            await Task.Yield();
            this._users.Update(user);
        }
    }
}
