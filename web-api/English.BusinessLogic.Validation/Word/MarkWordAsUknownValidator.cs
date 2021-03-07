using System;
using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public class MarkWordAsUknownValidator : ICommandValidator<MarkWordAsUknownCommand>
    {
        public Task Validate(MarkWordAsUknownCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
