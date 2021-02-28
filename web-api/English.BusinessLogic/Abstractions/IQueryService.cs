using System.Threading.Tasks;

namespace English.BusinessLogic
{
    public interface IQueryService<TQuery, TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}
