using System;
using System.Linq;
using System.Threading.Tasks;
using FS.Todo.Data.Interfaces;

namespace FS.Todo.Data.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly TodoContext todoContext;
        private TodoContext _todoContext;

        public StatusRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<Entities.Status> AddAsync(Entities.Status status)
        {
            status.Id = status.Id == Guid.Empty ? Guid.NewGuid() : status.Id;
            _todoContext.Add(status);
            await _todoContext.SaveChangesAsync();
            return status;
        }

        public async Task<Entities.Status> FindAsync(Guid id)
        {
            return await _todoContext.Status.FindAsync(id);
        }

        public async Task<IQueryable<Entities.Status>> Get()
        {
            return _todoContext.Status.AsQueryable();
        }

        public async Task RemoveAsync(Guid id)
        {
            var status = await _todoContext.Status.FindAsync(id);
            if (status is not null)
            {
                _todoContext.Status.Remove(status);
                await _todoContext.SaveChangesAsync();
            }
        }

        public async Task<Entities.Status> UpdateAsync(Entities.Status status)
        {
            var local = _todoContext.Status.Local.FirstOrDefault(entity => entity.Id == status.Id);
            if (local is not null)
            {
                _todoContext.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            _todoContext.Entry(status).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _todoContext.SaveChangesAsync();
            return status;
        }
    }
}