using System.Threading.Tasks;

namespace English.BusinessLogic.Services.Tests
{
    public class UserRepoFake : IUserRepository
    {
        public async Task<User> Find(int id)
        {
            await Task.Yield();

            return new User
            {
                Id = 123
            };
        }

        public Task Update(User user)
        {
            return Task.CompletedTask;
        }
    }
}
