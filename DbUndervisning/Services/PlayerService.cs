using DbUndervisning.Context;
using DbUndervisning.Model.Account;
using DbUndervisning.Services.Interfaces;
using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbUndervisning.Services
{
	public class PlayerService(IAsyncRepository<WorldContext> _asyncRepository) : IPlayerService
	{
		public async Task<Player> GetPlayerByName(string name)
		{
			return await _asyncRepository.GetItem<Player>(q => q.Where(x => x.Name == name).Include(c => c.Characters).ThenInclude(i => i.Abilities));
		}
	}
}
