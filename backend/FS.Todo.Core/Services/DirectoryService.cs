using System;
using System.Threading.Tasks;
using FS.Todo.Core.Models;
using FS.Todo.Data.Interfaces;


namespace FS.Todo.Core.Services
{
    public class DirectoryService 
    {
       
        private readonly IDirectoryRepository _directoryRepository;

        public DirectoryService(IDirectoryRepository directoryRepository)
        {
            _directoryRepository = directoryRepository;
        }

        public async Task<DirectoryModel> CreateDirectoryAsync(DirectoryModel directoryModel)
        {
            if (directoryModel is null)
            {
                throw new ArgumentNullException(nameof(directoryModel));
            }

            var directoryEntity = new Data.Entities.Directory
            {
                Name = directoryModel.Name,
                IsActive = directoryModel.IsActive,
                Id = directoryModel.Id,
                Module = directoryModel.Module, 
            };


            return new DirectoryModel
            {
                Id = directoryEntity.Id,
                Name = directoryEntity.Name,
                Module = directoryEntity.Module,
                IsActive = directoryEntity.IsActive,
            };
        }

 

        public async Task DeleteDirectoryAsync(Guid directoryId)
        {
            await _directoryRepository.RemoveAsync(directoryId);
        }

        public Task FindAsync(Guid directoryId)
        {
            return this._directoryRepository.FindAsync(directoryId);
        }

        public async Task<DirectoryModel> GetDirectoryAsync(Guid directoryId)
        {
            var directoryEntity = await _directoryRepository.FindAsync(directoryId);

            if (directoryEntity is null)
            {
                return null;
            }

            return new DirectoryModel
            {
                Name = directoryEntity.Name,
                Module = directoryEntity.Module,
                IsActive = directoryEntity.IsActive,
            };
        }

    }
}
