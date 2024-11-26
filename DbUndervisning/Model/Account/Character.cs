using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.Enums;
using DbUndervisning.Model.Quests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DbUndervisning.Model.Account
{
    [Table("Characters", Schema = "DbUndervisningProject")]
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
		public List<CharacterAbility> Abilities { get; set; } = new List<CharacterAbility>();

		public List<Item> Items { get; set; } = new List<Item>();
	}
}
