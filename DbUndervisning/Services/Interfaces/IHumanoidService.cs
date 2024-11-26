using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.NPCStuff;
using DbUndervisning.Model.Quests;

namespace DbUndervisning.Services.Interfaces
{
	public interface IHumanoidService
	{
		Task<Humanoid> GetHumanoidById(Guid id);
		Task<List<HumanoidAbility>> GetHumanoidAbilitiesById(Guid id);
		Task<List<Quest>> GetQuestByHumanoidId(Guid id);
	}
}