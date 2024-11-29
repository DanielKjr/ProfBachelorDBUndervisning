using DbUndervisning.Model;
using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.Account;
using DbUndervisning.Model.Enums;
using DbUndervisning.Model.NPCStuff;
using DbUndervisning.Model.Quests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Npgsql;

namespace DbUndervisning.Context
{
    public class WorldContext(IConfiguration _configuration) : DbContext
	{
		public DbSet<World> Worlds { get; set; }
		//public DbSet<Player> Players { get; set; }

		private static bool _logFileInitialized = false;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NPC>().Property(e => e.Behavior).HasConversion<string>();
			//modelBuilder.Entity<NPC>().HasOne(q => q.Quest).WithOne(n => n.NPC).HasForeignKey<Quest>(q=> q.NPCId);
			//modelBuilder.Entity<NPC>().HasMany(a=> a.Abilities).WithOne(n=> n.NPC).HasForeignKey(i=> i.NPCId);
			modelBuilder.Entity<NPC>()
	.HasOne(n => n.Quest)
	.WithOne(q => q.NPC)
	.HasForeignKey<Quest>(q => q.NPCId); // Foreign key in Quest pointing to NPC

			modelBuilder.Entity<NPC>()
				.HasMany(n => n.Abilities)
				.WithOne(a => a.NPC)
				.HasForeignKey(a => a.NPCId); // Foreign key in Ability pointing to NPC

			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();
			modelBuilder.Entity<Character>().Property(e => e.Class).HasConversion<string>();
			//modelBuilder.Entity<Mob>().Property(e => e.Class).HasConversion<string>();
			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();

			////Table per class så de får tabellen fra super klassen
			//modelBuilder.Entity<NPC>().UseTpcMappingStrategy();
			//modelBuilder.Entity<Ability>().UseTpcMappingStrategy();
			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!_logFileInitialized)
			{
				// Clear the file at the start of the application
				File.WriteAllText("sql_log.txt", string.Empty);
				_logFileInitialized = true;
			}

			optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextServer"]).LogTo(
			message =>
			{
				// Append log messages during runtime
				File.AppendAllText("sql_log.txt", Environment.NewLine + message + Environment.NewLine);
			},
			Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();

			//optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextServer"]);
			base.OnConfiguring(optionsBuilder);
		}
	}
}
