using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class Word
    {
        public Word()
        {
            this.Definitions = new List<Definition>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public IList<Definition> Definitions { get; set; }
    }
}
