using System;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Todo.Data.Interfaces
{
    public interface IStatusRepository
    {
        Task<Entities.Status> FindAsync(Guid id);
        Task<Entities.Status> UpdateAsync(Entities.Status statusEntity);
        Task<Entities.Status> AddAsync(Entities.Status status);
        Task RemoveAsync(Guid id);
        Task<IQueryable<Entities.Status>> Get();
   
        


    }
}
