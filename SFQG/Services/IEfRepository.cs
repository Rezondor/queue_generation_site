using System.Collections.Generic;
using System.Threading.Tasks;
using SFQG.Entities;

namespace SFQG.Services
{
    public interface IEfRepository<T> where T: BaseEntity
    {
        List<T> GetAll();
        T GetById(long id);
        Task<long> Add(T entity);
    }
}