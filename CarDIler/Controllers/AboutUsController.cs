using CarDIler.Data.Models.User;
using CarDIler.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarDIler.Controllers
{
    public class AboutUsController : Controller
    {
        public UserManager<User> _userManager;
        public AboutUsController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index() => View(_userManager.Users.ToList());
    }
}