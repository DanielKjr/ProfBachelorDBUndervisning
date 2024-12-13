using MultiPlayerDb.Model.Quests;

namespace MultiPlayerDb.Services.Interfaces
{
	public interface IHumanoidService
	{
		Task<Quest> GetQuestByHumanoidId(Guid id);
	}
}