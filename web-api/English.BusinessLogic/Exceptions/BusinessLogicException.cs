using System;

namespace English.BusinessLogic
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(): base()
        { }

        public BusinessLogicException(string message): base(message)
        { }
    }
}
