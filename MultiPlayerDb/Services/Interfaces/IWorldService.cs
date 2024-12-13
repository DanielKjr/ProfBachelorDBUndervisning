using MultiPlayerDb.Model;
using MultiPlayerDb.Model.Account;

namespace MultiPlayerDb.Services.Interfaces
{
	public interface IWorldService
    {
      
        public Task<World> GetWorld();
		public Task<Player> GetPlayer();
		public Task<World> GetWorldById(Guid id);
        public Task<World> GetWorldByName(string name);
        public void DeleteAll();
        Task<List<string>> GetQueries<TEntity>(List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> queryOperations) where TEntity : class;
		public Task<string> GetQuery<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryOperation) where TEntity : class;

        public void CreateStuff();
    }
}
