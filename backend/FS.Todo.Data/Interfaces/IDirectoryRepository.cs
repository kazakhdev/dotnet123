using System;

using System.Linq;

using System.Threading.Tasks;



namespace FS.Todo.Data.Interfaces
{
    public interface IDirectoryRepository
    {
        Task<Entities.Directory> FindAsync(Guid id);
      
        Task<Entities.Directory> AddAsync(Entities.Directory directory);
        Task RemoveAsync(Guid id);
       Task<IQueryable<Entities.Directory>> Get();
       
        Task<Entities.Directory> UpdateAsync(Entities.Directory directoryEntity);
        
    }
}
