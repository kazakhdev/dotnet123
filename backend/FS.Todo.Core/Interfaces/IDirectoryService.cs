using FS.Todo.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FS.Todo.Core.Interfaces
{
    public interface IDirectoryService
    {
        Task<DirectoryModel> CreateDirectoryAsync(DirectoryModel directoryModel);
        Task<DirectoryModel> UpdateDirectoryAsync(DirectoryModel directoryModel);
        Task<DirectoryModel> GetDirectoryAsync(Guid directoryId);
        Task DeleteDirectoryAsync(Guid directoryId);
        Task<List<DirectoryModel>> GetDirectoriesAsync();
        Task FindAsync(Guid directoryId);
    }
}
