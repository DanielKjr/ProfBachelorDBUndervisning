using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using MultiPlayerDb.Context;
using MultiPlayerDb.Model;
using MultiPlayerDb.Model.Account;
using MultiPlayerDb.Model.NPCStuff;
using MultiPlayerDb.Model.Quests;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Services
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


		public async Task<List<Guid>> GetAbilitiesByNPCID(Guid npcId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<NPC, Guid>(q => q.Where(i => i.Id == npcId).SelectMany(i => i.Abilities).Select(i => i.Id)));
		}

		public async Task<List<Guid>> GetQuestIdsFromHumanoidId(Guid npcId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<NPC, Guid>(q => q.Where(i => i.Id == npcId).Include(q => q.Quest).Select(i => i.Quest.Id)));
		}

		public async Task<List<Guid>> GetRegionIdsById(Guid worldId)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<Region, Guid>(q => q.Where(i => i.WorldId == worldId).Select(i => i.Id)));
		}

		public async Task<Guid> GetWorldIdByName(string name)
		{
			return  Task.FromResult(await _asyncRepository.GetAllForColumnStruct<World, Guid>(q => q.Where(i => i.Name == name).Select(i => i.Id))).Result.FirstOrDefault();
		}

		public async Task<List<Guid>> GetNPCIdsByRegionId(Guid region)
		{
			return await Task.FromResult(await _asyncRepository.GetAllForColumnStruct<Region, Guid>(q => q.Where(i => i.Id == region).Include(i => i.NPCS).SelectMany(i => i.NPCS.Select(i => i.Id))));
		}
	}
}
