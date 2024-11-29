namespace DbUndervisning.Services.Interfaces
{
	public interface IGuidService
	{
		public Task<Guid> GetWorldIdByName(string name);
		public Task<List<Guid>> GetRegionIdsById(Guid worldId);
		//public Task<List<Guid>> GetMobIdsByRegionId(Guid regionId);
		//public Task<List<Guid>> GetHumanoidIdsByRegionId(Guid regionId);
		public Task<List<Guid>> GetQuestIdsFromHumanoidId(Guid humanoidId);
		//public Task<List<Guid>> GetMobAbilityIdsByMobId(Guid mobId);
		//public Task<List<Guid>> GetHumanoidAbilityIdsByHumanoidId(Guid humanoidId);
		public Task<List<Guid>> GetCharacterItemsByCharacterId(Guid characterId);
		public Task<Guid> GetQuestItemByQuestId(Guid questId);

	}
}
