using Microsoft.AspNetCore.Mvc;
using MultiPlayerDb.Model.Account;
using MultiPlayerDb.Services;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Controllers
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
