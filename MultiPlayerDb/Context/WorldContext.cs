using Microsoft.EntityFrameworkCore;
using MultiPlayerDb.Model;
using MultiPlayerDb.Model.Abilities;
using MultiPlayerDb.Model.Account;
using MultiPlayerDb.Model.NPCStuff;
using MultiPlayerDb.Model.Quests;
namespace MultiPlayerDb.Context
{
	public class WorldContext(IConfiguration _configuration) : DbContext
	{
		public DbSet<World> Worlds { get; set; }
		public DbSet<Player> Players { get; set; }

		private static bool _logFileInitialized = false;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NPC>().Property(e => e.Behavior).HasConversion<string>();
			modelBuilder.Entity<NPC>()
	.HasOne(n => n.Quest)
	.WithOne(q => q.NPC)
	.HasForeignKey<Quest>(q => q.NPCId); // Foreign key in Quest pointing to NPC

			modelBuilder.Entity<Ability>()
	.HasOne(a => a.NPC)
	.WithMany(n => n.Abilities)
	.HasForeignKey(a => a.NPCId);

			modelBuilder.Entity<Ability>()
				.HasOne(a => a.Character)
				.WithMany(c => c.Abilities)
				.HasForeignKey(a => a.CharacterId);

			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();
			modelBuilder.Entity<Character>().Property(e => e.Class).HasConversion<string>();
			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();

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

	public class WorldContextAG(IConfiguration _configuration) : DbContext
	{
		public DbSet<World> Worlds { get; set; }
		public DbSet<Player> Players { get; set; }

		private static bool _logFileInitialized = false;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NPC>().Property(e => e.Behavior).HasConversion<string>();
			modelBuilder.Entity<NPC>()
	.HasOne(n => n.Quest)
	.WithOne(q => q.NPC)
	.HasForeignKey<Quest>(q => q.NPCId); // Foreign key in Quest pointing to NPC

			modelBuilder.Entity<Ability>()
	.HasOne(a => a.NPC)
	.WithMany(n => n.Abilities)
	.HasForeignKey(a => a.NPCId);

			modelBuilder.Entity<Ability>()
				.HasOne(a => a.Character)
				.WithMany(c => c.Abilities)
				.HasForeignKey(a => a.CharacterId);

			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();
			modelBuilder.Entity<Character>().Property(e => e.Class).HasConversion<string>();
			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();

			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		
			optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextAGServer"]);

			//optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextServer"]);
			base.OnConfiguring(optionsBuilder);
		}
	}

	public class WorldContextHP(IConfiguration _configuration) : DbContext
	{
		public DbSet<World> Worlds { get; set; }
		public DbSet<Player> Players { get; set; }

		private static bool _logFileInitialized = false;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NPC>().Property(e => e.Behavior).HasConversion<string>();
			modelBuilder.Entity<NPC>()
	.HasOne(n => n.Quest)
	.WithOne(q => q.NPC)
	.HasForeignKey<Quest>(q => q.NPCId); // Foreign key in Quest pointing to NPC

			modelBuilder.Entity<Ability>()
	.HasOne(a => a.NPC)
	.WithMany(n => n.Abilities)
	.HasForeignKey(a => a.NPCId);

			modelBuilder.Entity<Ability>()
				.HasOne(a => a.Character)
				.WithMany(c => c.Abilities)
				.HasForeignKey(a => a.CharacterId);

			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();
			modelBuilder.Entity<Character>().Property(e => e.Class).HasConversion<string>();
			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();

			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextHPServer"]);

			//optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextServer"]);
			base.OnConfiguring(optionsBuilder);
		}
	}

	public class WorldContextQZ(IConfiguration _configuration) : DbContext
	{
		public DbSet<World> Worlds { get; set; }
		public DbSet<Player> Players { get; set; }

		private static bool _logFileInitialized = false;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NPC>().Property(e => e.Behavior).HasConversion<string>();
			modelBuilder.Entity<NPC>()
	.HasOne(n => n.Quest)
	.WithOne(q => q.NPC)
	.HasForeignKey<Quest>(q => q.NPCId); // Foreign key in Quest pointing to NPC

			modelBuilder.Entity<Ability>()
	.HasOne(a => a.NPC)
	.WithMany(n => n.Abilities)
	.HasForeignKey(a => a.NPCId);

			modelBuilder.Entity<Ability>()
				.HasOne(a => a.Character)
				.WithMany(c => c.Abilities)
				.HasForeignKey(a => a.CharacterId);

			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();
			modelBuilder.Entity<Character>().Property(e => e.Class).HasConversion<string>();
			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();

			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextQZServer"]);

			//optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextServer"]);
			base.OnConfiguring(optionsBuilder);
		}
	}
}
