using DbUndervisning.Model;
using DbUndervisning.Model.NPCStuff;
using Microsoft.EntityFrameworkCore;

namespace DbUndervisning.Services
{
	public static class QueryableExtensions
	{
		public static IQueryable<Region> IncludeRegionRelations(this IQueryable<Region> query)
		{
			return query
				.Include(e => e.NPCS)
					.ThenInclude(e => e.Abilities)
					.Include(e => e.NPCS)
					.ThenInclude(e => e.Quest)
						.ThenInclude(e => e.ItemToCreate)
							.ThenInclude(e => e.Stats)
							.Include(e => e.NPCS)
					.ThenInclude(q => q.Quest)
						.ThenInclude(e => e.Reward);
		}

		public static IQueryable<World> IncludeAll(this IQueryable<World> query)
		{
			return query.Include(r => r.Regions)
				.ThenInclude(e => e.NPCS)
					.ThenInclude(e => e.Abilities)
				.Include(r => r.Regions)
					.ThenInclude(r => r.NPCS)
						.ThenInclude(a => a.Abilities)
				.Include(r => r.Regions)
					.ThenInclude(h => h.NPCS)
						.ThenInclude(q => q.Quest)
							.ThenInclude(e => e.ItemToCreate)
								.ThenInclude(u => u.Stats)
				.Include(r => r.Regions)
					.ThenInclude(h => h.NPCS)
						.ThenInclude(q => q.Quest)
							.ThenInclude(e => e.Reward);
		}
	
	}

}
