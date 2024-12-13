using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using MultiPlayerDb.Context;
using MultiPlayerDb.Model.Account;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Services
{
	
	public class PlayerService(IAsyncRepository<WorldContext> _asyncRepository) : IPlayerService
	{
		public async Task<Player> GetPlayerByName(string name)
		{
			return await _asyncRepository.GetItem<Player>(q => q.Where(x => x.Name == name).Include(c => c.Characters).ThenInclude(i => i.Abilities));
		}
	}
}
