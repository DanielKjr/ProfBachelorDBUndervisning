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
		public async Task<Quest> GetQuestByHumanoidId(Guid id)
		{
			var npc = await _asyncRepository.GetItem<NPC>(q => q.Where(i => i.Id == id).Include(q => q.Quest).ThenInclude(r => r.Reward).Include(q => q.Quest).ThenInclude(i => i.ItemToCreate).ThenInclude(s => s.Stats));
			return npc.Quest;
		}
	}
}
