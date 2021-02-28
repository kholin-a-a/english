using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class MarkWordAsUknownService : ICommandService<MarkWordAsUknown>
    {
        public Task ExecuteAsync(MarkWordAsUknown command)
        {
            return Task.CompletedTask;
        }
    }
}
