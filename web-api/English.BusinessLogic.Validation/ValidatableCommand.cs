using System.Threading.Tasks;

namespace English.BusinessLogic.Validation
{
    public class ValidatableCommand<TCommand> : ICommandService<TCommand>
    {
        private readonly ICommandService<TCommand> _commandService;
        private readonly ICommandValidator<TCommand> _commandValidator;

        public ValidatableCommand(
            ICommandService<TCommand> commandService,
            ICommandValidator<TCommand> commandValidator
        )
        {
            this._commandService = commandService;
            this._commandValidator = commandValidator;
        }

        public async Task ExecuteAsync(TCommand command)
        {
            await this._commandValidator.Validate(command);
            await this._commandService.ExecuteAsync(command);
        }
    }
}
