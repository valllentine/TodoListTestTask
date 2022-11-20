using Microsoft.AspNetCore.Mvc;
using TodoList.BLL.DTO;
using TodoList.BLL.Interfaces;
using TodoList.BLL.Services;


namespace TodoListTestTask.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _srvc;
        public TodoItemsController(ITodoItemService todoItemService)
        {
            _srvc = todoItemService;
        }

        // GET: api/<TodoItemsController>
        [HttpGet]
        public IEnumerable<TodoItemDTO> Get()
        {
            return _srvc.GetAll();
        }

        // GET api/<TodoItemsController>/5
        [HttpGet("{id}")]
        public TodoItemDTO Get(int id)
        {
            return _srvc.Get(id);
        }

        // POST api/<TodoItemsController>
        [HttpPost]
        public void Post(TodoItemDTO itemDTO)
        {
            _srvc.Create(itemDTO);
        }

        // PUT api/<TodoItemsController>/5
        [HttpPut]
        public void Put([FromBody] TodoItemDTO itemDTO)
        {
            _srvc.Update(itemDTO);
        }

        // DELETE api/<TodoItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _srvc.Delete(id);
        }
    }
}
