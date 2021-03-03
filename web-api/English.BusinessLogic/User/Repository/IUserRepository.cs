using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IUserRepository
    {
        Task<User> Find(int id);

        Task Update(User user);
    }
}
