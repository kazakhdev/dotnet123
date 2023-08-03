using FS.Todo.Core.Interfaces;
using FS.Todo.Core.Models;
using FS.Todo.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Todo.Core.Services
{
    public class DirectoryService : IDirectoryService
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

            directoryEntity = await _directoryRepository.AddAsync(directoryEntity);

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
        public Task FindAsync(Guid statusId)
        {
            throw new NotImplementedException();
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
         public async Task<List<DirectoryModel>> GetDirectoriesAsync()
        {
            IQueryable<Data.Entities.Directory> query = await _directoryRepository.Get();
            return await query.Select(directory => new DirectoryModel
            {
                Id = directory.Id,
                Name = directory.Name,
                Module = directory.Module,
                IsActive = directory.IsActive,
            })
            .ToListAsync();
        }

        public async Task<DirectoryModel> UpdateDirectoryAsync(DirectoryModel directoryModel)
        {
            throw new NotImplementedException();
        }

        public async Task<DirectoryModel> UpdateAsync(DirectoryModel directoryModel)
        {
            var directoryEntity = new Data.Entities.Directory
            {
                 Id = directoryModel.Id,
                Name = directoryModel.Name,
                Module = directoryModel.Module,
                IsActive = directoryModel.IsActive,
            };

            directoryEntity = await _directoryRepository.UpdateAsync(directoryEntity);

            return new DirectoryModel
            {
               Id = directoryEntity.Id,
                Name = directoryEntity.Name,
                Module = directoryEntity.Module,
                IsActive = directoryEntity.IsActive,
            };
        }

    }
}
