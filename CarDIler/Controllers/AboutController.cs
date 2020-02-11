using CarDIler.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarDIler.Controllers
{
    public class AboutController : Controller
    {
        UserManager<User> _userManager;
        public AboutController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index() => View(_userManager.Users.ToList());
    }
}