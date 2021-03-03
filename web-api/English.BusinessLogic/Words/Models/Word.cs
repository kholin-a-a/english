using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class Word
    {
        public Word()
        {
            this.Definitions = new Definition[0];
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public IEnumerable<Definition> Definitions { get; set; }
    }
}
