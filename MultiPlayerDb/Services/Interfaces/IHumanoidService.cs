using MultiPlayerDb.Model.Quests;

namespace MultiPlayerDb.Services.Interfaces
{
	public interface IHumanoidService
	{
		//Task<Humanoid> GetHumanoidById(Guid id);
		//Task<List<HumanoidAbility>> GetHumanoidAbilitiesById(Guid id);
		Task<Quest> GetQuestByHumanoidId(Guid id);
	}
}