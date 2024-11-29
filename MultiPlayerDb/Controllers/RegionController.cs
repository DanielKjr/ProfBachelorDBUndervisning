using Microsoft.AspNetCore.Mvc;
using MultiPlayerDb.Model;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RegionController(IRegionService _regionService) : ControllerBase
	{

		[HttpGet("world/{worldId}")]
		public async Task<Region> GetRegionByWorldId(Guid worldId)
		{
			return await Task.FromResult(await _regionService.GetRegionByWorldId(worldId));
		}

		[HttpGet("byId/{id}")]
		public async Task<Region> GetRegionById(Guid id)
		{
			return await Task.FromResult(await _regionService.GetRegionById(id));
		}


		[HttpDelete("deletebyid/{id}")]
		public void DeleteById(Guid id)
		{
			_regionService.DeleteRegionById(id);
		}

	}
}
