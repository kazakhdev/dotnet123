using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FS.Todo.Data;
using FS.Todo.Data.Entities;
using FS.Todo.Api.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FS.Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly TodoContext _context;

        public AdminsController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet("index")]
        [AuthorizedAction]
        public async Task<IActionResult> Index()
        {
            var adminsWithRoles = await _context.Admins.Include(a => a.Roles).ToListAsync();
            return Ok(adminsWithRoles);
        }

        [HttpGet("create")]
        [AuthorizedAction]
        public IActionResult Create()
        {
            var roles = _context.Roles.ToList();
            var adminModel = new AdminModel
            {
                Roles = roles
            };
            return Ok(adminModel);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] Admins admins)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admins);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest(ModelState);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var admins = await _context.Admins.FindAsync(id);
            if (admins == null)
            {
                return NotFound();
            }

            var roles = _context.Roles.ToList();
            var adminViewModel = new AdminModel
            {
                Id = admin.Id,
                FullName = admin.FullName,
                Email = admin.Email,
                RolesId = admin.RolesId,
                Roles = roles
            };

            return Ok(adminViewModel);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Admins updatedAdmin)
        {
            if (id != updatedAdmin.Id)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            admin.FullName = updatedAdmin.FullName;
            admin.Email = updatedAdmin.Email;
            admin.RolesId = updatedAdmin.RolesId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var admins = await _context.Admins.Include(a => a.Roles).SingleOrDefaultAsync(m => m.Id == id);
            if (admins == null)
            {
                return NotFound();
            }

            return Ok(admins);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admins = await _context.Admins.FindAsync(id);
            if (admins == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admins);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminsExists(int id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
    }
}