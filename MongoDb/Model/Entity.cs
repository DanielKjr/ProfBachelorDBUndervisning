using System.ComponentModel.DataAnnotations;

namespace MongoDb.Model
{

	public class Entity
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
