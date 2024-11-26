using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace DbUndervisning.Model.NPCStuff
{
    [Table("Mobs", Schema = "DbUndervisningProject")]
    public class Mob : NPC
    {
		
		public List<MobAbility> Abilities { get; set; } = new List<MobAbility>();

		//[ForeignKey("Id")]
		//public Guid NPCId { get; set; }

		//[ForeignKey("Id")]
		//public Guid RegionId { get; set; }
	}
}
