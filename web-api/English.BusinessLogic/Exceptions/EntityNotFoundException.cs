namespace English.BusinessLogic
{
    public class EntityNotFoundException : BusinessLogicException
    {
        public EntityNotFoundException(string message) : base(message)
        { }
    }
}
