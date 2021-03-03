using English.BusinessLogic;
using System;

namespace English.WebApi.Entry
{
    public class UserContextStub : IUserContext
    {
        public int UserId
        { 
            get => 11211;
            set => throw new NotImplementedException();
        }
    }
}
