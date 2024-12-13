using Microsoft.EntityFrameworkCore;
using MultiPlayerDb.Model;

namespace MultiPlayerDb.Services
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
						.ThenInclude(a => a.Abilities).AsSplitQuery()
				.Include(r => r.Regions)
					.ThenInclude(h => h.NPCS)
						.ThenInclude(q => q.Quest)
							.ThenInclude(e => e.ItemToCreate)
								.ThenInclude(u => u.Stats).AsSplitQuery()
				.Include(r => r.Regions)
					.ThenInclude(h => h.NPCS)
						.ThenInclude(q => q.Quest)
							.ThenInclude(e => e.Reward).AsSplitQuery();
		}
		//public static IQueryable<Region> IncludeNPCS(this IQueryable<Region> query)
		//{
		//	var result = query.Include(r => r.NPCs).ToList();

		//	foreach (var item in result)
		//	{
		//		if (item is Humanoid)
		//		{
		//			query.Include(r => r.NPCs)
		//					.ThenInclude(npc => (npc as Humanoid)!.Abilities)
		//					.Include(r => r.NPCs)
		//					.ThenInclude(npc => (npc as Humanoid)!.Quest)
		//						.ThenInclude(q => q.ItemToCreate)
		//					.Include(r => r.NPCs)
		//					.ThenInclude(npc => (npc as Humanoid)!.Quest)
		//						.ThenInclude(q => q.Reward);
		//		}
		//		else if (item is Mob)
		//		{
		//			query.Include(r => r.NPCs)
		//				.ThenInclude(npc => (npc as Mob)!.Abilities);
		//		}
		//	}

		//	return query;

		//	//        return query
		//	//.Include(r => r.NPCs) // Include the polymorphic NPC collection
		//	// .ThenInclude(npc => (npc as Mob)!.Abilities) // Include Abilities for Mobs
		//	//.Include(r => r.NPCs)
		//	// .ThenInclude(npc => (npc as Humanoid)!.Abilities) // Include Abilities for Humanoids
		//	//.Include(r => r.NPCs)
		//	// .ThenInclude(npc => (npc as Humanoid)!.Quest) // Include Quests for Humanoids
		//	//  .ThenInclude(q => q.ItemToCreate) // Include Items to Create in Quests
		//	//.Include(r => r.NPCs)
		//	// .ThenInclude(npc => (npc as Humanoid)!.Quest) // Include Quests for Humanoids
		//	//  .ThenInclude(q => q.Reward); // Include Rewards in Quests
		//}
	}

}
