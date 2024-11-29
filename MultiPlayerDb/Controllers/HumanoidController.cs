using Microsoft.AspNetCore.Mvc;
using MultiPlayerDb.Model.Quests;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HumanoidController(IHumanoidService _humanoidService) : ControllerBase
	{

		//[HttpGet("humanoidById/{humanoidID}")]
		//public async Task<Humanoid> GetHumanoidA(Guid humanoidID)
		//{
		//	return await Task.FromResult(await _humanoidService.GetHumanoidById(humanoidID));
		//}

		//[HttpGet("abilitiesById/{humanoidID}")]
		//public async Task<List<HumanoidAbility>> GetHumanoidAbilities(Guid humanoidID)
		//{
		//	return await Task.FromResult(await _humanoidService.GetHumanoidAbilitiesById(humanoidID));
		//}

		[HttpGet("questById/{humanoidID}")]
		public async Task<Quest> GetQuestByHumanoidId(Guid humanoidID)
		{
			return await Task.FromResult(await _humanoidService.GetQuestByHumanoidId(humanoidID));
		}
	}
}
