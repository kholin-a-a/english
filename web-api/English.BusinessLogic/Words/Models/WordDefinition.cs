using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class WordDefinition
    {
        public WordDefinition()
        {
            this.Synonyms = new Word[0];
        }

        public SpeechPart SpeechPart { get; set; }

        public string Definition { get; set; }

        public string Example { get; set; }

        public IEnumerable<Word> Synonyms { get; set; }
    }
}
