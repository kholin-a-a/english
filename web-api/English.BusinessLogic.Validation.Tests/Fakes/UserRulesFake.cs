using System.Threading.Tasks;

namespace English.BusinessLogic.Validation.Tests
{
    public class UserRulesFake : IUserRules
    {
        public Task HasLesson(int userId, int lessonId)
        {
            return Task.CompletedTask;
        }
    }
}
