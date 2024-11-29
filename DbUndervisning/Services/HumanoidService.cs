using DbUndervisning.Context;
using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.NPCStuff;
using DbUndervisning.Model.Quests;
using DbUndervisning.Services.Interfaces;
using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbUndervisning.Services
{
	public class HumanoidService(IAsyncRepository<WorldContext> _asyncRepository) : IHumanoidService
	{

		//public async Task<Humanoid> GetHumanoidById(Guid id)
		//{
		//	return await _asyncRepository.GetItem<Humanoid>(q => q.Where(i=> i.Id == id)
		//	.Include(a => a.Abilities).Include(q => q.Quest).ThenInclude(i=> i.ItemToCreate).ThenInclude(s => s.Stats)
		//	.Include(q => q.Quest).ThenInclude(r=> r.Reward));
		//}

		//public async Task<List<HumanoidAbility>> GetHumanoidAbilitiesById(Guid id)
		//{
		//	return await _asyncRepository.GetAllItems<HumanoidAbility>(q => q.Where(i => i.Id == id));
		//}

		public async Task<Quest> GetQuestByHumanoidId(Guid id)
		{
			var npc = await _asyncRepository.GetItem<NPC>(q => q.Where(i => i.Id == id).Include(q => q.Quest).ThenInclude(r => r.Reward).Include(q => q.Quest).ThenInclude(i => i.ItemToCreate).ThenInclude(s => s.Stats));
			return npc.Quest;
		}
	}
}
