using Microsoft.AspNetCore.Mvc;
using Session_Workshop.Models;

namespace Session_Workshop.Controllers
{
    public class Session : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            int? tableSession = HttpContext.Session.GetInt32("table");
            string? userSession = HttpContext.Session.GetString("user");
            if (tableSession != null || userSession != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetInt32("table", 22);
                HttpContext.Session.SetString("user", user.Name);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        [Route("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("math")]
        public IActionResult Operation(int operationid)
        {
            int? tableSession = HttpContext.Session.GetInt32("table");
            switch (operationid)
            {
                //Add
                case 1:
                    tableSession++;
                    break;
                //Subtraction
                case 2:
                    tableSession--;
                    break;
                //Multiply
                case 3:
                    tableSession = tableSession * 2;
                    break;
                //random
                case 4:
                    Random rand = new Random();
                    tableSession = tableSession + rand.Next(1,11);
                    break;
            }

            if (tableSession != null)
            {
                HttpContext.Session.SetInt32("table", (int)tableSession);
                return View("Dashboard");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
