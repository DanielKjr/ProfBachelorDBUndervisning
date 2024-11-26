using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbUndervisning.Model.Account
{
	[Table("Players", Schema = "DbUndervisningProject")]
	public class Player
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(25)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[StringLength(40)]
		public string HashedPw { get; set; } = string.Empty;

		public List<Character> Characters { get; set; } = new List<Character>();
	}
}
