using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace English.BusinessLogic.Services
{
    public class GetWordDefinitionsService : IQueryService<GetWordDefinitions, IEnumerable<WordDefinition>>
    {
        private readonly IWordDefinitionRepository _repo;

        public GetWordDefinitionsService(IWordDefinitionRepository repo)
        {
            this._repo = repo;
        }

        public Task<IEnumerable<WordDefinition>> ExecuteAsync(GetWordDefinitions query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return this._repo.DefineWord(query.WordId);

            var definitions = new WordDefinition[]
            {
                new WordDefinition
                {
                    SpeechPart = new SpeechPart { Name = "Noun" },
                    Definition = "activity requiring physical effort, carried out to sustain or improve health and fitness",
                    Example = "exercise improves your heart and lung power",
                    Synonyms = new Word[]
                    {
                        new Word { Text = "activity" },
                        new Word { Text = "movement" },
                        new Word { Text = "exercition" },
                        new Word { Text = "effort" },
                        new Word { Text = "work" }
                    }
                },
                new WordDefinition
                {
                    SpeechPart = new SpeechPart { Name = "Noun" },
                    Definition = "activity requiring physical effort, carried out to sustain or improve health and fitness",
                    Example = "exercise improves your heart and lung power",
                },
                new WordDefinition
                {
                    SpeechPart = new SpeechPart { Name = "Verb" },
                    Definition = "activity requiring physical effort, carried out to sustain or improve health and fitness",
                    Example = "exercise improves your heart and lung power",
                    Synonyms = new Word[]
                    {
                        new Word { Text = "activity" },
                        new Word { Text = "movement" },
                        new Word { Text = "exercition" },
                        new Word { Text = "effort" },
                        new Word { Text = "work" }
                    }
                }
            };

            return Task.FromResult(
                definitions.AsEnumerable()
                );
        }
    }
}
