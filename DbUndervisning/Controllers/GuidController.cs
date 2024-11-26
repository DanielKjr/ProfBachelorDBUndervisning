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

		[HttpGet("mobId/{regionId}")]
		public async Task<List<Guid>> GetMobIdsByRegionId(Guid regionId)
		{
			return await Task.FromResult(await _guidService.GetMobIdsByRegionId(regionId));
		}

		[HttpGet("humanoidId/{regionId}")]
		public async Task<List<Guid>> GetHumanoidsById(Guid regionId)
		{
			return await Task.FromResult(await _guidService.GetHumanoidIdsByRegionId(regionId));
		}
	}
}
