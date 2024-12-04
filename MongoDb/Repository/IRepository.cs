using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace MongoDb.Repository
{
	public interface IRepository<TContext> where TContext : MongoDb.Context.EntityContext
	{

		Task AddItem<TEntity>(TEntity entity) where TEntity : class;
		Task RemoveItem<TEntity>(TEntity entity) where TEntity : class;
		Task<TEntity> GetItem<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryOperation) where TEntity : class;
		Task UpdateItem<TEntity>(TEntity item) where TEntity : class;
		Task RemoveItem<TEntity>(Expression<Func<TEntity, bool>> searchExpression) where TEntity : class;
	
	}

	public class Repository<TContext>(IDbContextFactory<TContext> _dbContextFactory) : IRepository<TContext> where TContext : Context.EntityContext
	{
		

		public async Task AddItem<TEntity>(TEntity entity) where TEntity : class
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			await context.Set<TEntity>().AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public async Task<TEntity> GetItem<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryOperation) where TEntity : class
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			return await Task.FromResult(queryOperation(context.Set<TEntity>()).FirstOrDefault()!);

		}

		public async Task RemoveItem<TEntity>(TEntity entity) where TEntity : class
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			context.Set<TEntity>().Remove(entity);
			await context.SaveChangesAsync();
		}

		public async Task RemoveItem<TEntity>(Expression<Func<TEntity, bool>> searchExpression) where TEntity : class
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			TEntity entityToRemove = context.Set<TEntity>().Where(searchExpression).FirstOrDefault()!;
			if (entityToRemove != null)
			{
				context.Set<TEntity>().Remove(entityToRemove);
				await context.SaveChangesAsync();
			}
		}

		public async Task UpdateItem<TEntity>(TEntity item) where TEntity : class
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			context.Entry(item).State = EntityState.Modified;
			foreach (NavigationEntry navigationEntry in context.Entry(item).Navigations)
			{
				if (navigationEntry.Metadata.IsCollection &&
					navigationEntry.CurrentValue is IEnumerable<object> collection)
				{
					foreach (object entity in collection)
					{
						context.Entry(entity).State = EntityState.Modified;
					}
				}
			}
			await context.SaveChangesAsync();
		}
	}
}
