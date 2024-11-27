using DbUndervisning.Model;
using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.Account;
using DbUndervisning.Model.DTOs;
using DbUndervisning.Model.Quests;
using DbUndervisning.Services;
using DbUndervisning.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DbUndervisning.Controllers
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

		[HttpGet("getqueries")]
		public async Task<List<string>> GetQueries()
		{
			var s = new List<Func<IQueryable<World>, IQueryable<World>>>();

			s.Add(q => q.Where(i => i.Id != null).IncludeAll());
			s.Add(q => q.Where(i => i.Id != null).IncludeAll());

			return await Task.FromResult(await _worldService.GetQueries(s));
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
