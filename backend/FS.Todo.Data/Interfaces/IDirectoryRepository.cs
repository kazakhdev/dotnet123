using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Todo.Data.Interfaces;
using FS.Todo.Data.Entities;

namespace FS.Todo.Data.Interfaces
{
    public interface IDirectoryRepository
    {
        Task<Entities.Directory> FindAsync(Guid id);
      
        Task<Entities.Directory> AddAsync(Entities.Directory directory);
        Task RemoveAsync(Guid id);
        IQueryable<Entities.Directory> Get();
        Task<Entities.Directory> UpdateAsync(Entities.Directory directoryEntity);
        
    }
}
