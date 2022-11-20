using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.DTO;

namespace TodoList.BLL.Interfaces
{
    public interface ITodoItemService
    {
        IEnumerable<TodoItemDTO> GetAll();
        TodoItemDTO Get(int ID);
        void Create(TodoItemDTO entity);
        void Update(TodoItemDTO entity);
        void Delete(int ID);
    }
}
