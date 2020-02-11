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
        private readonly SqlContext _db;
        public AboutController(UserManager<User> userManager, SqlContext context)
        {
            _userManager = userManager;
            _db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            AboutViewModel avw = new AboutViewModel
            {
                Users = _userManager.Users.AsNoTracking().ToList(),
                Abouts = _db.Abouts.AsNoTracking().FirstOrDefault()
            }; 
                 
            return View(avw);
        }
    }
}