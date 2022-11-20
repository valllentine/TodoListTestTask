using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DAL.Entities;
using TodoList.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TodoList.DAL.Repositories.Realizations
{
    public class TodoItemRepository : IRepositoryBase<TodoItem>
    {
        private readonly TodoListDBContext _context;

        public TodoItemRepository(TodoListDBContext context)
        {
            this._context = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.ToDoItems;
        }

        public TodoItem Get(int id)
        {
            return _context.ToDoItems.Find(id);
        }

        public void Create(TodoItem item)
        {
            _context.ToDoItems.Add(item);
            _context.SaveChanges();
        }

        public void Update(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TodoItem item = _context.ToDoItems.Find(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
            }

            _context.SaveChanges();
        }
    }
}
