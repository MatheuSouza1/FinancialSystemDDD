using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generic
{
    public interface InterfaceGeneric<T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
