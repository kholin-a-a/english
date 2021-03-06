using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class Lesson
    {
        public Lesson()
        {
            this.Answers = new List<Answer>();
        }

        public int Id { get; set; }

        public IList<Answer> Answers { get; set; }
    }
}
