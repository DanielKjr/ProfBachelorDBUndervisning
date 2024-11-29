using DbUndervisning.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DbUndervisning.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GuidController(IGuidService _guidService) : ControllerBase
	{


		[HttpGet("worldName/{name}")]
		public async Task<Guid> GetWorldIdByName(string name)
		{
			return await Task.FromResult(await _guidService.GetWorldIdByName(name));
		}

		[HttpGet("regionId/{worldId}")]
		public async Task<List<Guid>> GetRegionIdsById(Guid worldId)
		{
			return await Task.FromResult(await _guidService.GetRegionIdsById(worldId));
		}

		//[HttpGet("mobId/{regionId}")]
		//public async Task<List<Guid>> GetMobIdsByRegionId(Guid regionId)
		//{
		//	return await Task.FromResult(await _guidService.GetMobIdsByRegionId(regionId));
		//}

		//[HttpGet("mobAbilitiesById/{mobId}")]
		//public async Task<List<Guid>> GetMobAbilitiesById(Guid mobId)
		//{
		//	return await Task.FromResult(await _guidService.GetMobAbilityIdsByMobId(mobId));
		//}

		//[HttpGet("humanoidId/{regionId}")]
		//public async Task<List<Guid>> GetHumanoidsById(Guid regionId)
		//{
		//	return await Task.FromResult(await _guidService.GetHumanoidIdsByRegionId(regionId));
		//}


		//[HttpGet("humanoidAbilities/{humanoidId}")]
		//public async Task<List<Guid>> GetHumanoidAbilitiesById(Guid humanoidId)
		//{
		//	return await Task.FromResult(await _guidService.GetHumanoidAbilityIdsByHumanoidId(humanoidId));
		//}

		[HttpGet("characterItems/{characterId}")]
		public async Task<List<Guid>> GetCharacterItemsById(Guid characterId)
		{
			return await Task.FromResult(await _guidService.GetCharacterItemsByCharacterId(characterId));
		}

		[HttpGet("questItems/{questId}")]
		public async Task<Guid> GetQuestItemsById(Guid questId)
		{
			return await Task.FromResult(await _guidService.GetQuestItemByQuestId(questId));
		}

		[HttpGet("questByHumanoidId/{humanoidID}")]
		public async Task<List<Guid>> GetQuestByHumanoidId(Guid humanoidID)
		{
			return await Task.FromResult(await _guidService.GetQuestIdsFromHumanoidId(humanoidID));
		}


	}
}
