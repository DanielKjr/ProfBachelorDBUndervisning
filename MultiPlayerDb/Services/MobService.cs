using EF_InteractionFrameworkCore.Interfaces;
using MultiPlayerDb.Context;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Services
{
	public class MobService(IAsyncRepository<WorldContext> _asyncRepository) : IMobService
	{

		//public async Task<Mob> GetMobById(Guid id)
		//{
		//	return await _asyncRepository.GetItem<Mob>(q=> q.Where(i=> i.Id == id).Include(i => i.Abilities));
		//}

		//public async Task<List<MobAbility>> GetMobsAbilitiesById(Guid id)
		//{
		//	var abilities = await _asyncRepository.GetAllItems<MobAbility>(q => q.Where(x => x.Id == id));

		//	return abilities ?? new List<MobAbility>();
		//}

		//public async Task<List<MobAbility>> GetMobsAbilitiesByMobId(Guid mobId)
		//{
		//	var abilities = await _asyncRepository.GetAllItems<MobAbility>(q => q.Where(x => x.MobId == mobId));


		//	return abilities ?? new List<MobAbility>();
		//}
	}
}
