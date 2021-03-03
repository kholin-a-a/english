namespace English.BusinessLogic.Services.Tests
{
    public class UserContextFake : IUserContext
    {
        public UserContextFake()
        {
            this.UserId = 11211;
        }

        public int UserId { get; set; }
    }
}
