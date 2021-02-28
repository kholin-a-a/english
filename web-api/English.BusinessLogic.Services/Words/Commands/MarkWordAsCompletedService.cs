using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class MarkWordAsCompletedService : ICommandService<MarkWordAsCompleted>
    {
        public Task ExecuteAsync(MarkWordAsCompleted command)
        {
            return Task.CompletedTask;
        }
    }
}
