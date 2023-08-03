using System;
using System.Linq;
using System.Threading.Tasks;
using FS.Todo.Data.Interfaces;

namespace FS.Todo.Data.Repositories
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly TodoContext todoContext;
        private TodoContext _todoContext;

        public DirectoryRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<Entities.Directory> AddAsync(Entities.Directory directory)
        {
            directory.Id = directory.Id == Guid.Empty ? Guid.NewGuid() : directory.Id;
            _todoContext.Add(directory);
            await _todoContext.SaveChangesAsync();
            return directory;
        }

        public async Task<Entities.Directory> FindAsync(Guid id)
        {
            return await _todoContext.Directory.FindAsync(id);
        }

        public async Task<IQueryable<Entities.Directory>> Get()
        {
            return _todoContext.Directory.AsQueryable();
        }

        public async Task RemoveAsync(Guid id)
        {
            var directory = await _todoContext.Directory.FindAsync(id);
            if (directory is not null)
            {
                _todoContext.Directory.Remove(directory);
                await _todoContext.SaveChangesAsync();
            }
        }

        public async Task<Entities.Directory> UpdateAsync(Entities.Directory directory)
        {
            var local = _todoContext.Directory.Local.FirstOrDefault(entity => entity.Id == directory.Id);
            if (local is not null)
            {
                _todoContext.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            _todoContext.Entry(directory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _todoContext.SaveChangesAsync();
            return directory;
        }
    }
}