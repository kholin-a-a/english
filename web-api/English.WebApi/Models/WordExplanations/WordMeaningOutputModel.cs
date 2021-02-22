namespace English.WebApi.Models
{
    public class WordMeaningOutputModel
    {
        public string Meaning { get; set; }

        public string Example { get; set; }

        public string[] Synonyms { get; set; }
    }
}
