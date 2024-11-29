using DbUndervisning.Context;
using DbUndervisning.Model;
using DbUndervisning.Services.Interfaces;
using EF_InteractionFrameworkCore;
using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbUndervisning.Services
{
	public class RegionService(IAsyncRepository<WorldContext> _asyncRepository) : IRegionService
	{
		public async Task<Region> GetRegionById(Guid id)
		{
			return await _asyncRepository.GetItem<Region>(q => q.Where(x => x.Id == id).IncludeRegionRelations());
		}


		public async Task<Region> GetRegionByWorldId(Guid id)
		{
			return await _asyncRepository.GetItem<Region>(q => q.Where(x => x.WorldId == id).Include(m => m.NPCS));
		}

		public async void DeleteRegionById(Guid id)
		{
			await _asyncRepository.RemoveItems<Region>(x => x.Where(q => q.Id == id).IncludeRegionRelations());
		}
	}
}
