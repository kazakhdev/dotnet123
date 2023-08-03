using FS.Todo.Api.Models;
using FS.Todo.Core.Interfaces;
using FS.Todo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Reflection.PortableExecutable;

namespace FS.Todo.Api.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class  DirectoryController: ControllerBase
        {
            private readonly IDirectoryService _directoryService;

            public DirectoryController(IDirectoryService directoryService)
            {
                _directoryService = directoryService;
            }

            [HttpGet("{id}")]
            [ActionName("GetDirectoryAsync")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<DirectoryModel>> GetTodoAsync(Guid id)
            {
                var directories = await _directoryService.GetDirectoryAsync(id);

                if (directories is null)
                {
                    return NotFound();
                }

                return Ok(directories);
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<List<DirectoryModel>>> GetDirectoryAsync(Guid id)
            {
                var directories = await _directoryService.GetDirectoryAsync(id);
                return Ok(directories);
            }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            public async Task<ActionResult<DirectoryModel>> CreateDirectoryAsync(CreateDirectoryModel createDirectoryModel)
            {
                var directoryModel = new DirectoryModel
                {
                    Id = createDirectoryModel.Id,
                    Name = createDirectoryModel.Name,
                    Module = createDirectoryModel.Module,
                    IsActive = createDirectoryModel.IsActive,
                };

                var createdDirectory = await _directoryService.CreateDirectoryAsync(directoryModel);

                return CreatedAtAction(nameof(GetDirectoryAsync), new { id = createdDirectory.Id }, createdDirectory);
            }


            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult> UpdateDirectoryAsync(Guid id, UpdateDirectoryModel updateDirectoryModel)
            {
                if (id != updateDirectoryModel.Id)
                {
                    return BadRequest();
                }

                var directory = await _directoryService.GetDirectoryAsync(id);
                if (directory is null)
                {
                    return NotFound();
                }

                var directoryModel = new DirectoryModel
                {
                    Id = updateDirectoryModel.Id,
                    Name = updateDirectoryModel.Name,
                    Module = updateDirectoryModel.Module,
                    IsActive = updateDirectoryModel.IsActive,
                };

                var updatedDirectory = await _directoryService.UpdateDirectoryAsync(directoryModel);

                return NoContent();
            }

            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public async Task<ActionResult> DeleteDirectoryAsync(Guid id)
            {
                var directory = await _directoryService.GetDirectoryAsync(id);
                if (directory is null)
                {
                    return NotFound();
                }

                await _directoryService.DeleteDirectoryAsync(id);
                return NoContent();
            }

        }
    
}
