namespace English.BusinessLogic.Validation.Tests
{
    public class UserContextFake : IUserContext
    {
        public UserContextFake()
        {
            this.UserId = 123;
        }

        public int UserId { get; set; }
    }
}
