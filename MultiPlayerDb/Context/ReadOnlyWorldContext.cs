using Microsoft.EntityFrameworkCore;
using MultiPlayerDb.Model;
using MultiPlayerDb.Model.Abilities;
using MultiPlayerDb.Model.Account;
using MultiPlayerDb.Model.NPCStuff;
using MultiPlayerDb.Model.Quests;

namespace MultiPlayerDb.Context
{
	public class ReadOnlyWorldContext(IConfiguration _configuration) : DbContext
	{
		public DbSet<World> Worlds { get; set; }
		public DbSet<Player> Players { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NPC>().Property(e => e.Behavior).HasConversion<string>();
			modelBuilder.Entity<NPC>().HasOne(n => n.Quest).WithOne(q => q.NPC).HasForeignKey<Quest>(q => q.NPCId);

			modelBuilder.Entity<Ability>().HasOne(a => a.NPC).WithMany(n => n.Abilities).HasForeignKey(a => a.NPCId);
			modelBuilder.Entity<Ability>().HasOne(a => a.Character).WithMany(c => c.Abilities).HasForeignKey(a => a.CharacterId);

			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();
			modelBuilder.Entity<Character>().Property(e => e.Class).HasConversion<string>();
			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();
			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{


			optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextReadOnlyServer"]);

			//optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextServer"]);
			base.OnConfiguring(optionsBuilder);
		}
	}

}

