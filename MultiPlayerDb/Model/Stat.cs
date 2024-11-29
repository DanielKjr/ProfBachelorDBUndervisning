using MultiPlayerDb.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPlayerDb.Model
{
	[Table("Stats", Schema = "MultiPlayerDb")]
	public class Stat
	{
		[Key]
		public Guid Id { get; set; }

		[ForeignKey("Id")]
		public Guid ItemId { get; set; }

		[Required]
		[StringLength(25)]
		public string Name { get; set; } = string.Empty;
		[Required]
		[StringLength(150)]
		public string Description { get; set; } = string.Empty;

		[Required]
		public double Boost { get; set; }

		[Required]
		public StatType StatType { get; set; }
		
	}
}
