using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class User
    {
        public User()
        {
            this.Lessons = new List<Lesson>();
            this.UnknownWords = new List<Word>();
        }

        public int Id { get; set; }

        public IList<Lesson> Lessons { get; set; }

        public IList<Word> UnknownWords { get; set; }
    }
}
