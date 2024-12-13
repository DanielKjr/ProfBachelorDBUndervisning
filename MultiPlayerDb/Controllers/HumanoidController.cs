using Microsoft.AspNetCore.Mvc;
using MultiPlayerDb.Model.Quests;
using MultiPlayerDb.Services;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HumanoidController(IHumanoidService _humanoidService) : ControllerBase
	{
		[HttpGet("questById/{humanoidID}")]
		public async Task<Quest> GetQuestByHumanoidId(Guid humanoidID)
		{
			return await Task.FromResult(await _humanoidService.GetQuestByHumanoidId(humanoidID));
		}
	}
}
