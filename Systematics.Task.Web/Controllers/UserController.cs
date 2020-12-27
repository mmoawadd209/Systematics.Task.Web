using Microsoft.AspNetCore.Mvc;
using Systematics.Task.Web.Models;

namespace Systematics.Task.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            return View();
        }
    }
}
