using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbUndervisning.Model.Quests
{
    [Table("Quests", Schema = "DbUndervisningProject")]
    public class Quest
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Id")]
        public Guid HumanoidId { get; set; }

		[Required]
        public string Title { get; set; } = string.Empty;

        public string Dialogue { get; set; } = string.Empty;

        public string Objective { get; set; } = string.Empty;

        public Reward? Reward { get; set; } 

        public Item? ItemToCreate { get; set; }
	}
}
