using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public interface IUserRules
    {
        Task HasLesson(int userId, int lessonId);
    }
}
