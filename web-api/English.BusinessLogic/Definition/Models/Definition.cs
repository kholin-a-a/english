using System.Collections.Generic;

namespace English.BusinessLogic
{
    public class Definition
    {
        public Definition()
        {
            this.Synonyms = new string[0];
        }

        public string SpeechPart { get; set; }

        public string Value { get; set; }

        public string Example { get; set; }

        public IEnumerable<string> Synonyms { get; set; }
    }
}
