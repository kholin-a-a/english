using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface ICommandValidator<TCommand>
    {
        Task Validate(TCommand command);
    }
}
