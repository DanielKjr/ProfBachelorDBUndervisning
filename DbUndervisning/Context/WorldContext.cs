﻿using DbUndervisning.Model;
using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.Account;
using DbUndervisning.Model.Enums;
using DbUndervisning.Model.NPCStuff;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DbUndervisning.Context
{
    public class WorldContext(IConfiguration _configuration) : DbContext
	{
		public DbSet<World> Worlds { get; set; }
		public DbSet<Player> Players { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NPC>().Property(e => e.Behavior).HasConversion<string>();
			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();
			modelBuilder.Entity<Character>().Property(e => e.Class).HasConversion<string>();
			modelBuilder.Entity<Mob>().Property(e => e.Class).HasConversion<string>();
			modelBuilder.Entity<Ability>().Property(e => e.ClassConstraint).HasConversion<string>();

			//Table per class så de får tabellen fra super klassen
			modelBuilder.Entity<NPC>().UseTpcMappingStrategy();
			modelBuilder.Entity<Ability>().UseTpcMappingStrategy();
			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextServer"]).LogTo(
			//message =>
			//{
			//	File.AppendAllText("sql_log.txt", Environment.NewLine + message + Environment.NewLine);
			//},
			//Microsoft.Extensions.Logging.LogLevel.Information);
			optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DbContextServer"]);
			base.OnConfiguring(optionsBuilder);
		}
	}
}
