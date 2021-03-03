using System.Threading.Tasks;

namespace English.BusinessLogic.Services.Tests
{
    public class UserRepoFake : IUserRepository
    {
        public UserRepoFake()
        {
            this.User = new User
            {
                Id = 123
            };
        }

        public User User { get; set; }

        public Task<User> Find(int id)
        {
            return Task.FromResult(this.User);
        }

        public Task Update(User user)
        {
            return Task.CompletedTask;
        }
    }
}
