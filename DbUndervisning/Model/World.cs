using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbUndervisning.Model
{
	[Table("Worlds", Schema = "DbUndervisningProject")]
	public class World
	{

		[Key]
		public Guid Id { get; set; }

		[StringLength(25)]
		[Required]
		public string Name { get; set; } = string.Empty;

		[NotMapped]
		public int WorldSize { get => Regions.Count(); }

		public List<Region> Regions { get; set; } = new List<Region>();

	}
}
