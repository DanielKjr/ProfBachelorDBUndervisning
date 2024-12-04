using Microsoft.AspNetCore.Mvc;
using MongoDb.Context;
using MongoDb.Model;
using MongoDb.Repository;

namespace MongoDb.Controllers
{
	public class EntityController(IRepository<EntityContext> _repository) : ControllerBase
	{

		[HttpPost("api/entity")]
		public async Task<IActionResult> AddEntity([FromBody]Entity entity)
		{
			await _repository.AddItem(entity);
			return Ok();
		}
	}
}
