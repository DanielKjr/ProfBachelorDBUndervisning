namespace MultiPlayerDb.Services.Interfaces
{
	public interface IGuidService
	{
		public Task<Guid> GetWorldIdByName(string name);
		public Task<List<Guid>> GetRegionIdsById(Guid worldId);
		public Task<List<Guid>> GetNPCIdsByRegionId(Guid region);
		public Task<List<Guid>> GetQuestIdsFromHumanoidId(Guid humanoidId);
		public Task<List<Guid>> GetAbilitiesByNPCID(Guid npcId);

		public Task<List<Guid>> GetCharacterItemsByCharacterId(Guid characterId);
		public Task<Guid> GetQuestItemByQuestId(Guid questId);

	}
}
