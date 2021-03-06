using System.Threading.Tasks;

namespace English.BusinessLogic.Validation.Tests
{
    public class UserRepoFake : IUserRepository
    {
        public UserRepoFake()
        {
            this.User = new User();
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
