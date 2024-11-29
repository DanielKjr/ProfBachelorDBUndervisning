using MultiPlayerDb.Model.Account;

namespace MultiPlayerDb.Services.Interfaces
{
	public interface IPlayerService
	{

		public Task<Player> GetPlayerByName(string name);
	}
}
