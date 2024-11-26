using DbUndervisning.Context;
using DbUndervisning.Model;
using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.NPCStuff;
using DbUndervisning.Model.Quests;
using DbUndervisning.Services.Interfaces;
using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbUndervisning.Services
{
	public class GuidService(IAsyncRepository<WorldContext> _asyncRepository) : IGuidService
	{
		public async Task<List<Guid>> GetHumanoidAbilityIdsByHumanoidId(Guid humanoidId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<HumanoidAbility, Guid>(q=> q.Where(i => i.Id == humanoidId).Select(i=> i.Id)));
		}

		public async Task<List<Guid>> GetHumanoidIdsByRegionId(Guid regionId)
		{
			return await _asyncRepository.GetAllForColumnStruct<Region, Guid>(
				q => q
					.Where(i => i.Id == regionId)
					.Include(r => r.Humanoids)
					.SelectMany(r => r.Humanoids.Select(h => h.Id))
			);
		}


		public async Task<List<Guid>> GetMobAbilityIdsByMobId(Guid mobId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<MobAbility, Guid>(q => q.Where(i => i.Id == mobId).Select(i => i.Id)));
		}

		public async Task<List<Guid>> GetMobIdsByRegionId(Guid regionId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<Region, Guid>(q => q.Where(i => i.Id == regionId).Include(m=> m.Mobs).ThenInclude(e => e.Abilities).SelectMany(m=> m.Mobs.Select(i => i.Id))));
		}

		public async Task<List<Guid>> GetQuestIdsFromHumanoidId(Guid humanoidId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<Quest, Guid>(q => q.Where(i => i.HumanoidId == humanoidId).Select(i => i.Id)));
		}

		public async Task<List<Guid>> GetRegionIdsById(Guid worldId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<Region, Guid>(q => q.Where(i => i.WorldId == worldId).Select(i => i.Id)));
		}

		public async Task<Guid> GetWorldIdByName(string name)
		{
			var s = await _asyncRepository.GetAllForColumnStruct<World, Guid>(q => q.Where(i => i.Name == name).Select(i => i.Id));
			
			return await Task.FromResult(s.FirstOrDefault());
		}
	}
}
