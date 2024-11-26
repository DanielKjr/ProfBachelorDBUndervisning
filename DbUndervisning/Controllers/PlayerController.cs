using DbUndervisning.Model.Account;
using DbUndervisning.Services;
using DbUndervisning.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DbUndervisning.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PlayerController(IPlayerService _playerService) : ControllerBase
	{

		[HttpGet("player/{name}")]
		public async Task<Player> GetPlayer(string name)
		{
			return await Task.FromResult(await _playerService.GetPlayerByName(name));
		}
	}
}
