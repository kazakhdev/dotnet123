using FS.Todo.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FS.Todo.Core.Interfaces
{
    public interface IStatusService
    {
        Task<StatusModel> CreateStatusAsync(StatusModel statusModel);
        Task<StatusModel> UpdateStatusAsync(StatusModel statusModel);
        Task<StatusModel> GetStatusAsync(Guid statusId);
        Task DeleteStatusAsync(Guid statusId);
        Task<List<StatusModel>> GetStatusesAsync();
        
        Task FindAsync(Guid statusId);
    }
}
