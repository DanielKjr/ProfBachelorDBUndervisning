using Microsoft.AspNetCore.Mvc;
using MultiPlayerDb.Model;
using MultiPlayerDb.Model.Account;
using MultiPlayerDb.Services;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Controllers
{
	[ApiController]
	[Route("[controller]")]
    public class WorldController(IWorldService _worldService) : ControllerBase
	{


		[HttpGet("get")]
		public async Task<World> GetWorld()
		{

			return await Task.FromResult(await _worldService.GetWorld());
		}

		[HttpGet("get/player")]
		public async Task<Player> GetPlayer()
		{

			return await Task.FromResult(await _worldService.GetPlayer());
		}


		[HttpGet("worldName/{name}")]
		public async Task<World> GetWorld(string name)
		{
			
			return await Task.FromResult(await _worldService.GetWorldByName(name));
		}

		[HttpGet("worldId/{id}")]
		public async Task<World> GetWorld(Guid id)
		{
			return await Task.FromResult(await _worldService.GetWorldById(id));
		}






		[HttpGet("getquery")]
		public async Task<string> GetQuery()
		{
			var world = await _worldService.GetWorldByName("Kandarin");
			return await Task.FromResult(await _worldService.GetQuery<World>(q=> q.Where(i=> i.Id == world.Id).IncludeAll()));
		}


		[HttpPost("create")]	
		public void CreateStuff()
		{
			_worldService.CreateStuff();
		}

		[HttpDelete("deleteall")]
		public void DeleteAll()
		{
			_worldService.DeleteAll();
		}

	}
}
