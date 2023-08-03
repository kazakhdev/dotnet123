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
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<StatusModel> CreateStatusAsync(StatusModel statusModel)
        {
            if (statusModel is null)
            {
                throw new ArgumentNullException(nameof(statusModel));
            }

            var statusEntity = new Data.Entities.Status
            {
                 Pending = statusModel.Pending,
                 Indevelopment = statusModel.Indevelopment,
                 Testing = statusModel.Testing,
                 Closed = statusModel.Closed,
                 Classification = statusModel.Classification,
                 Analytics = statusModel.Analytics,
                 Model = statusModel.Model,
                 Name = statusModel.Name,
                 Code = statusModel.Code,
    };

            statusEntity = await _statusRepository.AddAsync(statusEntity);

            return new StatusModel
            {
                Pending = statusEntity.Pending,
                Indevelopment = statusEntity.Indevelopment,
                Testing = statusEntity.Testing,
                Closed = statusEntity.Closed,
                Classification = statusEntity.Classification,
                Analytics = statusEntity.Analytics,
                Model = statusEntity.Model,
                Name = statusEntity.Name,
                Code = statusEntity.Code,
            };
        }

        public async Task DeleteStatusAsync(Guid statusId)
        {
            await _statusRepository.RemoveAsync(statusId);
        }

        public Task FindAsync(Guid statusId)
        {
            throw new NotImplementedException();
        }

        public async Task<StatusModel> GetStatusAsync(Guid statusId)
        {
            var statusEntity = await _statusRepository.FindAsync(statusId);

            if (statusEntity is null)
            {
                return null;
            }

            return new StatusModel
            {
                Pending = statusEntity.Pending,
                Indevelopment = statusEntity.Indevelopment,
                Testing = statusEntity.Testing,
                Closed = statusEntity.Closed,
                Classification = statusEntity.Classification,
                Analytics = statusEntity.Analytics,
                Model = statusEntity.Model,
                Name = statusEntity.Name,
                Code = statusEntity.Code,
            };
        }

        public async Task<List<StatusModel>> GetStatusesAsync()
        {
            IQueryable<Data.Entities.Status> query = await _statusRepository.Get();
            return await query.Select(status => new StatusModel
            {
              Pending = status.Pending,
                Indevelopment = status.Indevelopment,
                Testing = status.Testing,
                Closed = status.Closed,
                Classification = status.Classification,
                Analytics = status.Analytics,
                Model = status.Model,
                Name = status.Name,
                Code = status.Code,
            })
            .ToListAsync();
        }

        public Task<StatusModel> UpdateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();
        }

        public async Task<StatusModel> UpdateTodoAsync(StatusModel statusModel)
        {
            var statusEntity = new Data.Entities.Status
            {
                 Pending = statusModel.Pending,
                 Indevelopment = statusModel.Indevelopment,
                 Testing = statusModel.Testing,
                 Closed = statusModel.Closed,
                 Classification = statusModel.Classification,
                 Analytics = statusModel.Analytics,
                 Model = statusModel.Model,
                 Name = statusModel.Name,
                 Code = statusModel.Code,
            };

            statusEntity = await _statusRepository.UpdateAsync(statusEntity);

            return new StatusModel
            {
                Pending = statusEntity.Pending,
                Indevelopment = statusEntity.Indevelopment,
                Testing = statusEntity.Testing,
                Closed = statusEntity.Closed,
                Classification = statusEntity.Classification,
                Analytics = statusEntity.Analytics,
                Model = statusEntity.Model,
                Name = statusEntity.Name,
                Code = statusEntity.Code,
            };
        }
    }
    }
