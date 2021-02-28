using System.Collections.Generic;

namespace English.WebApi.Models
{
    public class WordDefinitionOutputModel
    {
        public WordDefinitionOutputModel()
        {
            this.Synonyms = new string[0];
        }

        public string SpeechPart { get; set; }

        public string Definition { get; set; }

        public string Example { get; set; }

        public IEnumerable<string> Synonyms { get; set; }
    }
}
