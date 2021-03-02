using System.Collections.Generic;
using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IWordDefinitionRepository
    {
        Task<IEnumerable<WordDefinition>> DefineWord(int wordId);
    }
}
