using MultiPlayerDb.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MultiPlayerDb.Model
{
	[Table("Items", Schema = "MultiPlayerDb")]
	public class Item
	{

		[Key]
		public Guid Id { get; set; }
		[Required]
		[StringLength(25)]
		public string Name { get; set; } = string.Empty;
		[Required]
		[StringLength(150)]
		public string Description { get; set; } = string.Empty;
		[Required]
		public RarityLevel Rarity { get; set; }
		
		public List<Stat> Stats { get; set; } = new List<Stat>();
	

		public string Texture { get; set; } = string.Empty;
	}
}
