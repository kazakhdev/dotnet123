using FS.Todo.Api.Models;
using FS.Todo.Core.Interfaces;
using FS.Todo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace FS.Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        //Интерфейс создать нужно + поле StatusService
        private readonly IStatusService _statusService;

                                    //Интерфейс + метод
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("{id}")]
        [ActionName("GetStatusAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //Модель StatusModel + 
        public async Task<ActionResult<StatusModel>> GetStatusAsync(Guid id)
        {
            var status = await _statusService.GetStatusAsync(id);

            if (status is null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<StatusModel>>>GetStatusesAsync()
        {
            var statuses = await _statusService.GetStatusesAsync();
            return Ok(statuses);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<StatusModel>> CreateStatusAsync(CreateStatusModel createStatusModel)
        {
            var statusModel = new StatusModel
            {
                Pending = createStatusModel.Pending,
                Indevelopment = createStatusModel.Indevelopment,
                Testing = createStatusModel.Testing,
                Closed = createStatusModel.Closed,
                Classification = createStatusModel.Classification,
                Analytics = createStatusModel.Analytics,
                Model = createStatusModel.Model,
                Name = createStatusModel.Name,
                Code = createStatusModel.Code,
            };

            var createdStatus = await _statusService.CreateStatusAsync(statusModel);

            return CreatedAtAction(nameof(GetStatusAsync), new { id = createdStatus.Id }, createdStatus);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateStatusAsync(Guid id, UpdateStatusModel updateStatusModel)
        {
            if (id != updateStatusModel.Id)
            {
                return BadRequest();
            }

            var status = await _statusService.GetStatusAsync(id);
            if (status is null)
            {
                return NotFound();
            }

            var statusModel = new StatusModel
            {
                Pending = updateStatusModel.Pending,
                Indevelopment = updateStatusModel.Indevelopment,
                Testing = updateStatusModel.Testing,
                Closed = updateStatusModel.Closed,
                Classification = updateStatusModel.Classification,
                Analytics = updateStatusModel.Analytics,
                Model = updateStatusModel.Model,
                Name = updateStatusModel.Name,
                Code = updateStatusModel.Code,
            };

            var updatedStatus = await _statusService.UpdateStatusAsync(statusModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteStatusAsync(Guid id)
        {
            var status = await _statusService.GetStatusAsync(id);
            if (status is null)
            {
                return NotFound();
            }

            await _statusService.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}
