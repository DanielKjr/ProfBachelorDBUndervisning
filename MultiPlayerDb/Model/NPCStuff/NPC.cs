using MultiPlayerDb.Model.Abilities;
using MultiPlayerDb.Model.Enums;
using MultiPlayerDb.Model.Quests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPlayerDb.Model.NPCStuff
{
	[Table("NPCs", Schema = "MultiPlayerDb")]
	public class NPC
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(25)]
		public string Name { get; set; }

		[Required]
		[StringLength(25)]
		public string Class { get; set; }

		[Required]
		public int Level { get; set; } = 1;

		[Required]
		public int Health { get; set; }

		[Required]
		public bool Attackable { get; set; }

		[Required]
		public string Position { get; set; }

		[Required]
		public BehaviorType Behavior { get; set; }

		public string Texture { get; set; }

		public List<Ability> Abilities { get; set; } = new List<Ability>();
		public Quest Quest { get; set; }
	}

}
