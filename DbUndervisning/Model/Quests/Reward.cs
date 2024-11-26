using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbUndervisning.Model.Quests
{
	[Table("Rewards", Schema = "DbUndervisningProject")]
	public class Reward
	{
		[Key]
		public Guid Id { get; set; }

		[ForeignKey("Id")]
		public Guid QuestId { get; set; }

		[Required]
		public double Currency { get; set; }

		[Required]
		public double Experience { get; set; }
	}
}
