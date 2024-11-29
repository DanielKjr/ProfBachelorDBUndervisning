using MultiPlayerDb.Model;

namespace MultiPlayerDb.Services.Interfaces
{
	public interface IRegionService
	{
		public Task<Region> GetRegionById(Guid id);
		public Task<Region> GetRegionByWorldId(Guid id);
		public void DeleteRegionById(Guid id);
	}
}
