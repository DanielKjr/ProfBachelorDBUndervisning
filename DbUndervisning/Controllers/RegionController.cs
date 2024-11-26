using DbUndervisning.Model;
using DbUndervisning.Services;
using DbUndervisning.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DbUndervisning.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RegionController(IRegionService _regionService) : ControllerBase
	{

		[HttpGet("region/world/{worldId}")]
		public async Task<Region> GetRegionByWorldId(Guid worldId)
		{
			return await Task.FromResult(await _regionService.GetRegionByWorldId(worldId));
		}

		[HttpGet("region/{id}")]
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
