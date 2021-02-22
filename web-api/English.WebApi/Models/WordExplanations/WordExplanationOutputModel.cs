using System.Collections.Generic;

namespace English.WebApi.Models
{
    public class WordExplanationOutputModel
    {
        public string Part { get; set; }

        public IEnumerable<WordMeaningOutputModel> Meanings { get; set; }
    }
}
