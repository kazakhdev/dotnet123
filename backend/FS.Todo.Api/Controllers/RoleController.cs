using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FS.Todo.Data;
using FS.Todo.Data.Entities;

namespace FS.Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private TodoContext _context;

        public RolesController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        [AuthorizedAction]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        // GET: api/Roles/Edit/5
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var menuIds = _context.LinkRolesMenus.Where(s => s.RolesId == id).Select(s => s.MenusId.ToString()).ToList();
            var menus = _context.Menus.ToList();

            var sb = new StringBuilder();
            string unorderedList = GenerateUL(menus, menuIds, sb);

            var roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                Title = role.Title,
                Description = role.Description,
                MenuList = unorderedList
            };

            return Ok(roleViewModel);
        }

        // POST: api/Roles/Edit/5
        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditRole(int id, RoleViewModel roleViewModel)
        {
            if (id != roleViewModel.Id)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            role.Title = roleViewModel.Title;
            role.Description = roleViewModel.Description;

            var existingRoleMenus = _context.LinkRolesMenus.Where(s => s.RolesId == id);
            _context.LinkRolesMenus.RemoveRange(existingRoleMenus);

            foreach (var menuId in roleViewModel.SelectedMenuIds)
            {
                _context.LinkRolesMenus.Add(new LinkRolesMenus { MenusId = menuId, RolesId = id });
            }

            await _context.SaveChangesAsync();

            return Ok(new { status = true, message = "Role updated successfully!" });
        }

        private string GenerateUL(List<Menus> menus, List<string> menuIds, StringBuilder sb)
        {
            foreach (var menu in menus)
            {
                string id = menu.Id.ToString();
                string menuText = menu.Name;
                string status = menuIds.Contains(id) ? "Checked" : "";

                sb.AppendLine($"<li><input type=\"checkbox\" name=\"subdomain[]\" id=\"{id}\" value=\"{id}\" {status}><label>{menuText}</label>");

                if (menu.Menus1.Any())
                {
                    sb.AppendLine("<ul>");
                    GenerateUL(menu.Menus1.ToList(), menuIds, sb);
                    sb.AppendLine("</ul>");
                }

                sb.AppendLine("</li>");
            }

            return sb.ToString();
        }

        private bool RolesExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }

        public class RoleViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public List<int> SelectedMenuIds { get; set; }
            public string MenuList { get; set; }
        }
    }
}