using Microsoft.AspNetCore.Mvc;
using Seeder.BusinessLayer.Managers.Interfaces;
using Seeder.Core.Entities.Items;

namespace Seeder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoManager _todoManager;

        public TodoController(ITodoManager todoManager)
        {
            _todoManager = todoManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoManager.GetAll();
            return new ObjectResult(todos);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetTodo(int id)
        {
            var todo = _todoManager.Get(id);

            if (todo == null) return NotFound();

            return new ObjectResult(todo);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Todo todo)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            _todoManager.Add(todo);

            return CreatedAtRoute("GetTodo", new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Todo todo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id == todo.Id) return BadRequest("Id's are not matching");

            var entity = _todoManager.Get(id);

            if (entity == null) return NotFound();

            _todoManager.Update(todo);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _todoManager.Get(id);

            if (entity == null) return NotFound();

            _todoManager.Delete(id);

            return NoContent();
        }
    }
}
