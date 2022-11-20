using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.DTO;
using TodoList.BLL.Interfaces;
using TodoList.DAL.Entities;
using TodoList.DAL.Repositories.Interfaces;
using AutoMapper;

namespace TodoList.BLL.Services
{
    public class TodoItemService : ITodoItemService
    {
        public readonly IRepositoryBase<TodoItem> _repository;
        private Mapper _ItemMapper;
        public TodoItemService(IRepositoryBase<TodoItem> repository)
        {
            _repository = repository;

            var _config = new MapperConfiguration(ctg => ctg.CreateMap<TodoItem, TodoItemDTO>().ReverseMap());
            _ItemMapper = new Mapper(_config);
        }

        public IEnumerable<TodoItemDTO> GetAll()
        {
            IEnumerable<TodoItem> itmFromDB = _repository.GetAll();
            IEnumerable<TodoItemDTO> itemDTOs = _ItemMapper.Map<IEnumerable<TodoItem>, IEnumerable<TodoItemDTO>>(itmFromDB);
            return itemDTOs;
        }

        public TodoItemDTO Get(int id)
        {
            TodoItem itmFromDB = _repository.Get(id);
            TodoItemDTO itemDTO = _ItemMapper.Map<TodoItem, TodoItemDTO>(itmFromDB);
            return itemDTO;
        }

        public void Create(TodoItemDTO itemDTO)
        {
            itemDTO.ID = 0;
            TodoItem itmFromDB = _ItemMapper.Map<TodoItemDTO, TodoItem>(itemDTO);
            _repository.Create(itmFromDB);
        }

        public void Update(TodoItemDTO itemDTO)
        {
            TodoItem itmFromDB = _ItemMapper.Map<TodoItemDTO, TodoItem>(itemDTO);
            _repository.Update(itmFromDB);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
