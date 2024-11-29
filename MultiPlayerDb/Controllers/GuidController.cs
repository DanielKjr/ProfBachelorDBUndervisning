using Microsoft.AspNetCore.Mvc;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Controllers
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

		[HttpGet("abilitiesById/{npcId}")]
		public async Task<List<Guid>> GetMobAbilitiesById(Guid npcId)
		{
			return await Task.FromResult(await _guidService.GetAbilitiesByNPCID(npcId));
		}

		[HttpGet("npcs/{regionId}")]
		public async Task<List<Guid>> GetNPCSByRegionId(Guid regionId)
		{
			return await Task.FromResult(await _guidService.GetNPCIdsByRegionId(regionId));
		}


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
