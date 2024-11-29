using DbUndervisning.Model.NPCStuff;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DbUndervisning.Model
{
	[Table("Regions", Schema = "DbUndervisningProject")]
	public class Region
	{
		[Key]
		public Guid Id { get; set; }

		[ForeignKey("Id")]
		[Required]
		public Guid WorldId { get; set; }

		[StringLength(25)]
		[Required]
		public string Name { get; set; } = string.Empty;
		[StringLength(200)]
		[Required]
		public string Description { get; set; } = string.Empty;
		[Required]
		public string Size { get; set; }

		[StringLength(200)]
		[Comment("placeholder siden jeg ikke har noget reelt asset")]
		public string Asset { get; set; } = string.Empty;

		public List<NPC> NPCS { get; set; } = new List<NPC>();
		//public List<Mob> Mobs { get; set; } = new List<Mob>();
		//public List<Humanoid> Humanoids { get; set; } = new List<Humanoid>();

		//public List<NPC> NPCs { get; set; } = new List<NPC>();
	}
}
