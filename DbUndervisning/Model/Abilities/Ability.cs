using DbUndervisning.Model.Enums;
using DbUndervisning.Model.NPCStuff;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbUndervisning.Model.Abilities
{
	[Table("Abilities", Schema = "DbUndervisningProject")]
	public class Ability
	{
		[Key]
		public Guid Id { get; set; }

		// Foreign key linking to NPC.Id
		public Guid NPCId { get; set; }
		public NPC NPC { get; set; }

		[Required]
		[StringLength(25)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[StringLength(150)]
		public string Description { get; set; } = string.Empty;

		[Required]
		public double Damage { get; set; }

		[Required]
		public ClassType ClassConstraint { get; set; }
	}


	//[Table("CharacterAbilities", Schema = "DbUndervisningProject")]
	//public class CharacterAbility: Ability
	//   {
	//       [ForeignKey("Id")]
	//       public Guid CharacterId { get; set; }
	//}

	//[Table("MobAbilities", Schema = "DbUndervisningProject")]
	//public class MobAbility : Ability
	//{
	//	[ForeignKey("Id")]
	//	public Guid MobId { get; set; }
	//}

	//[Table("HumanoidAbilities", Schema = "DbUndervisningProject")]
	//public class HumanoidAbility : Ability
	//{
	//	[ForeignKey("Id")]
	//	public Guid HumanoidId { get; set; }
	//}
}
