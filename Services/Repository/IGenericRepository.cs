using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T entity);
        Task Delete(int id);
        Task Deactivate(int id);
        Task<T> GetByField(string fieldName, object value);
    }
}
