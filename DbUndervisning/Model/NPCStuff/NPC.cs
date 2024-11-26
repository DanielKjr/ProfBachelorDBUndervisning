using DbUndervisning.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DbUndervisning.Model.NPCStuff
{
    public abstract class NPC
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

    }
}
