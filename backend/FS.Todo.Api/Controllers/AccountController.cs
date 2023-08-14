using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FS.Todo.Data;
using FS.Todo.Data.Entities;
using System.Text;

namespace FS.Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TodoContext _db;

        public AccountController(TodoContext context)
        {
            _db = context;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("validate")]
        public IActionResult Validate([FromBody] Admins admin)
        {
            var _admin = _db.Admins.FirstOrDefault(s => s.Email == admin.Email);
            if (_admin != null)
            {
                if (_admin.Password == admin.Password)
                {
                    HttpContext.Session.SetString("email", _admin.Email);
                    HttpContext.Session.SetInt32("id", _admin.Id);
                    HttpContext.Session.SetInt32("role_id", (int)_admin.RolesId);
                    HttpContext.Session.SetString("name", _admin.FullName);

                    int roleId = (int)HttpContext.Session.GetInt32("role_id");
                    List<Menus> menus = _db.LinkRolesMenus.Where(s => s.RolesId == roleId).Select(s => s.Menus).ToList();

                    DataSet ds = ToDataSet(menus);
                    DataTable table = ds.Tables[0];
                    DataRow[] parentMenus = table.Select("ParentId = 0");

                    StringBuilder sb = new StringBuilder();
                    string menuString = GenerateUL(parentMenus, table, sb);
                    HttpContext.Session.SetString("menuString", menuString);
                    HttpContext.Session.SetString("menus", JsonConvert.SerializeObject(menus));

                    return Ok(new { status = true, message = "Login Successful!" });
                }
                else
                {
                    return Ok(new { status = true, message = "Invalid Password!" });
                }
            }
            else
            {
                return Ok(new { status = false, message = "Invalid Email!" });
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private string GenerateUL(DataRow[] menu, DataTable table, StringBuilder sb)
        {
            if (menu.Length > 0)
            {
                foreach (DataRow dr in menu)
                {
                    string url = dr["Url"].ToString();
                    string menuText = dr["Name"].ToString();
                    string icon = dr["Icon"].ToString();

                    if (url != "#")
                    {
                        string line = $@"<li><a href=""{url}""><i class=""{icon}""></i> <span>{menuText}</span></a></li>";
                        sb.Append(line);
                    }

                    string pid = dr["Id"].ToString();
                    string parentId = dr["ParentId"].ToString();

                    DataRow[] subMenu = table.Select($"ParentId = '{pid}'");
                    if (subMenu.Length > 0 && !pid.Equals(parentId))
                    {
                        string line = $@"<li class=""treeview""><a href=""#""><i class=""{icon}""></i> <span>{menuText}</span><span class=""pull-right-container""><i class=""fa fa-angle-left pull-right""></i></span></a><ul class=""treeview-menu"">";
                        sb.AppendLine(line);
                        sb.Append(GenerateUL(subMenu, table, sb));
                        sb.Append("</ul></li>");
                    }
                }
            }
            return sb.ToString();
        }

        private DataSet ToDataSet<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = Props.Select(prop => prop.GetValue(item)).ToArray();
                dataTable.Rows.Add(values);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dataTable);
            return ds;
        }
    }
}