using DbUndervisning.Model.Account;

namespace DbUndervisning.Services.Interfaces
{
	public interface IPlayerService
	{

		public Task<Player> GetPlayerByName(string name);
	}
}
