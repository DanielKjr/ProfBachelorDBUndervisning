using Microsoft.EntityFrameworkCore;
using MongoDb.Model;

namespace MongoDb.Context
{
	public class EntityContext(IConfiguration _configuration) : DbContext
	{
		public DbSet<Entity> Entities { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMongoDB(_configuration["MongoDb"], _configuration["MongoDbName"]);
		}
	}
}
