using DbUndervisning.Context;
using DbUndervisning.Model;
using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.Account;
using DbUndervisning.Model.NPCStuff;
using DbUndervisning.Model.Quests;
using DbUndervisning.Services.Interfaces;
using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbUndervisning.Services
{
	public class GuidService(IAsyncRepository<WorldContext> _asyncRepository) : IGuidService
	{

		public async Task<List<Guid>> GetCharacterItemsByCharacterId(Guid characterId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<Character, Guid>(
				q => q.Where(i => i.Id == characterId)
				.Include(i => i.Items)
				.SelectMany(o => o.Items
				.Select(i => i.Id)))
				);
		}

		public async Task<Guid> GetQuestItemByQuestId(Guid questId)
		{
			var id = await _asyncRepository.GetAllForColumnStruct<Quest, Guid>(q => q.Where(i => i.Id == questId).Include(i => i.ItemToCreate).Select(o => o.ItemToCreate.Id));
			return await Task.FromResult(id.FirstOrDefault());
		}



		public async Task<List<Guid>> GetQuestIdsFromHumanoidId(Guid humanoidId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<NPC, Guid>(q => q.Where(i => i.Id == humanoidId).Include(q => q.Quest).Select(i => i.Quest.Id)));
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
