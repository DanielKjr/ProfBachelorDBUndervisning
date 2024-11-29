using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.NPCStuff;
using DbUndervisning.Services;
using DbUndervisning.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace DbUndervisning.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MobController(IMobService _mobService) : ControllerBase
	{

		//[HttpGet("byId/{id}")]
		//public async Task<Mob> GetMob(Guid id)
		//{
		//	return await Task.FromResult(await _mobService.GetMobById(id));
		//}

		//[HttpGet("mobabilities/mobId/{id}")]
		//public async Task<List<MobAbility>> GetMobAbilitiesByMobId(Guid id)
		//{
		//	return await Task.FromResult(await _mobService.GetMobsAbilitiesByMobId(id));
		//}

		//[HttpGet("mobabilities/{id}")]
		//public async Task<List<MobAbility>> GetMobAbilities(Guid id)
		//{
		//	return await Task.FromResult(await _mobService.GetMobsAbilitiesById(id));
		//}

	}
}
