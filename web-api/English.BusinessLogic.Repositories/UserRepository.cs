using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
