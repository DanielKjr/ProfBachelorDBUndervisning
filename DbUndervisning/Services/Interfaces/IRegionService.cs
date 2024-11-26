using DbUndervisning.Model;
using DbUndervisning.Model.Quests;

namespace DbUndervisning.Services.Interfaces
{
	public interface IRegionService
	{
		public Task<Region> GetRegionById(Guid id);
		public Task<Region> GetRegionByWorldId(Guid id);
		public void DeleteRegionById(Guid id);
	}
}
