using MultiPlayerDb.Model.Abilities;
using MultiPlayerDb.Model.Enums;
using MultiPlayerDb.Model.Quests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPlayerDb.Model.Account
{
	[Table("Characters", Schema = "MultiPlayerDb")]
	public class Character
	{
		[Key]
		public Guid Id { get; set; }

		[ForeignKey("Id")]
		public Guid PlayerId { get; set; }

		[Required]
		public int Level { get; set; }
		[Required]
		public ClassType Class { get; set; }
		[Required]
		[StringLength(25)]
		public string Name { get; set; } = string.Empty;
		[Required]
		public double Currency { get; set; }
		[Required]
		public string Position { get; set; }
		public List<Quest> CompletedQuests { get; set; } = new List<Quest>();
		public List<Ability> Abilities { get; set; } = new List<Ability>();

		public List<Item> Items { get; set; } = new List<Item>();
	}
}
