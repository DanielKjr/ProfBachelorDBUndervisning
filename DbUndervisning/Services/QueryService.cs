using DbUndervisning.Context;
using DbUndervisning.Services.Interfaces;
using EF_InteractionFrameworkCore.Interfaces;

namespace DbUndervisning.Services
{
	public class QueryService(IAsyncRepository<WorldContext> _asyncRepository) : IQueryService
	{


		public async Task<string> GetQuery<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryOperation) where TEntity : class
		{
			return await _asyncRepository.GetQueryString(queryOperation);
		}

		public async Task<List<string>> GetQueries<TEntity>(List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> queryOperations) where TEntity : class
		{
			var queryStrings = new List<string>();
			queryOperations.ForEach(async i => queryStrings.Add(await _asyncRepository.GetQueryString(i)));
			return queryStrings;
		}
	}
}
