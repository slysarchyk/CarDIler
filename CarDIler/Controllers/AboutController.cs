using CarDIler.Data.Models.User;
using CarDIler.Models;
using CarDIler.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarDIler.Controllers
{
    public class AboutController : Controller
    {
        UserManager<User> _userManager;
        public AboutController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() => View();
    }
}