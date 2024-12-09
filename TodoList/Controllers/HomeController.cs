using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
       
        public HomeController()
        {
           
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

    }
}