using DbUndervisning.Model.Abilities;
using DbUndervisning.Services;
using DbUndervisning.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace DbUndervisning.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MobController(IMobService _mobService) : ControllerBase
	{


		[HttpGet("mobabilities/{id}")]
		public async Task<List<MobAbility>> GetMobAbilities(Guid id)
		{
			return await Task.FromResult(await _mobService.GetMobsAbilitiesById(id));
		}

	}
}
