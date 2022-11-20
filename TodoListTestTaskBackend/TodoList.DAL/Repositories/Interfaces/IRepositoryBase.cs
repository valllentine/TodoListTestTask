using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.DAL.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int ID);
        void Create(T entity);
        void Update(T entity);
        void Delete(int ID);
    }
}
