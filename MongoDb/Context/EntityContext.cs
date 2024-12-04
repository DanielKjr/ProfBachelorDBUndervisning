using Microsoft.EntityFrameworkCore;
using MongoDb.Model;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MongoDb.Context
{
	public class EntityContext(IConfiguration _configuration) : DbContext
	{
		public DbSet<Entity> Entities { get; set; }

	

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMongoDB(_configuration["ConnectionStrings:MongoDb"], _configuration["ConnectionStrings:MongoDbName"]);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Entity>().ToCollection("entities");
		}
	}
}
