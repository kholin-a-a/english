using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ICommandService<TCommand>
    {
        Task ExecuteAsync(TCommand command);
    }
}
