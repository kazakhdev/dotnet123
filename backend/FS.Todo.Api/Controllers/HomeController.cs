using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FS.Todo.Data;

namespace FS.Todo.Api.Controllers
{
    public class HomeController : Controller
    {
        private TodoContext db;
        public HomeController(TodoContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return Redirect("/Account/Login");
            }

            return View();
        }


    }
}