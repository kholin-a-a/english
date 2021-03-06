using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class User
    {
        public User()
        {
            this.Lessons = new List<Lesson>();
        }

        public int Id { get; set; }

        public IList<Lesson> Lessons { get; set; }
    }
}
