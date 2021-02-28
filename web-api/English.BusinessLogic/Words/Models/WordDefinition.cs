using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class WordDefinition
    {
        public SpeechPart SpeechPart { get; set; }

        public string Definition { get; set; }

        public string Example { get; set; }

        public IEnumerable<Word> Synonyms { get; set; }
    }
}
