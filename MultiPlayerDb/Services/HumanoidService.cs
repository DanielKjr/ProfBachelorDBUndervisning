using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using MultiPlayerDb.Context;
using MultiPlayerDb.Model.NPCStuff;
using MultiPlayerDb.Model.Quests;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Services
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
