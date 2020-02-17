﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarDIler.Data.Models;
using CarDIler.Data.Models.Car;
using CarDIler.Data.Models.User;
using CarDIler.Models;
using CarDIler.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDIler.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SqlContext _db;
        IWebHostEnvironment _appEnvironment;
        UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public AdminController(SqlContext context, 
            IWebHostEnvironment appEnvironment, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _db = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 6;

            var car = _db.Cars.
                Include(b => b.Brand).
                AsNoTracking().
                ToList();

            var user = _userManager.Users.ToList();

            var count = car.Count();
            PageViewModel pvw = new PageViewModel(count, page, pageSize);

            AdminViewModel avm = new AdminViewModel
            {
                Cars = car.Where(s => s.Sold == true).
                OrderByDescending(x => x.Id).
                Skip((page - 1) * pageSize).
                Take(pageSize).
                ToList(),
                PageViewModels = pvw,

                SSold = car.Count(s => s.Sold == false),
                SSoldOut = car.Count(s => s.Sold == true),
                SSPrice = car.Where(s => s.Sold == true).Sum(s => s.PriceBrutto),
                SSProfit = car.Where(s => s.Sold == true).Sum(s => s.Profit),
                Users = user
            };

            return View(avm);
        }

        [HttpGet]
        public IActionResult AddCar() => View();

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car, IFormFile cover, IFormFileCollection uploads)
        {
            if (ModelState.IsValid)
            {
                string coverPath = "/images/Cars/" + cover.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + coverPath, FileMode.Create))
                {
                    await cover.CopyToAsync(fileStream);
                }

                var user = await _userManager.GetUserAsync(User);

                Car cars = new Car
                {
                    Name = car.Name,
                    Sold = car.Sold,
                    Engine = car.Engine,
                    Distance = car.Distance,
                    PriceNetto = car.PriceNetto,
                    PriceBrutto = (0.2 * car.PriceNetto) + car.PriceNetto,
                    Profit = (0.18 * (0.2 * car.PriceNetto)) + (0.2 * car.PriceNetto),
                    BrandId = car.BrandId,
                    Category = car.Category,
                    Year = car.Year,
                    Fuel = car.Fuel,
                    Vin = car.Vin,
                    Color = car.Color,
                    Desc = car.Desc,
                    Date = DateTime.Now.ToShortDateString(),
                    CoverPath = coverPath,
                    AddByName = user.Name,
                    AddBySurname = user.SurName,
                    AddByPosition = user.Position,
                    AddByPhoneNumber = user.PhoneNumber
                };
                _db.Cars.Add(cars);
                _db.SaveChanges();

                foreach (var uploadedFile in uploads)
                {
                    string path = "/images/" + uploadedFile.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    CarImages galerys = new CarImages { Path = path, CarId = cars.Id };

                    _db.CarImages.Add(galerys);
                    _db.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditCar(int? id)
        {
            Car car = await _db.Cars.AsNoTracking().
                Where(x => x.Id == id).
                SingleOrDefaultAsync();
            if (car == null)
                return NotFound();

            var viewModel = new EditCarViewModel 
            {
                Name = car.Name,
                Sold = car.Sold,
                Desc = car.Desc,
                Engine = car.Engine,
                Distance = car.Distance,
                Color = car.Color,
                Vin = car.Vin,
                PriceNetto = car.PriceNetto,
                CoverPath = car.CoverPath,
                Year = car.Year
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(EditCarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Car car = await _db.Cars.
                    Where(x => x.Id == viewModel.Id).
                    FirstOrDefaultAsync();

                var user = await _userManager.GetUserAsync(User);

                if (car == null)
                    return NotFound();

                car.Name = viewModel.Name;
                car.Sold = viewModel.Sold;
                car.Desc = viewModel.Desc;
                car.Year = viewModel.Year;
                car.Engine = viewModel.Engine;
                car.Distance = viewModel.Distance;
                car.Color = viewModel.Color;
                car.Vin = viewModel.Vin;
                car.PriceNetto = viewModel.PriceNetto;
                car.PriceBrutto = (0.2 * viewModel.PriceNetto) + viewModel.PriceNetto;
                car.Profit = (0.18 * (0.2 * viewModel.PriceNetto)) + (0.2 * viewModel.PriceNetto);
                car.DateEdit = DateTime.Now.ToShortDateString();
                car.AddByName = user.Name;
                car.AddBySurname = user.SurName;
                car.AddByPosition = user.Position;
                car.AddByPhoneNumber = user.PhoneNumber;

                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DelCar(int id)
        {
            Car car = new Car { Id = id };
            _db.Entry(car).State = EntityState.Deleted;
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        //секція блогу
        [HttpGet]
        public ActionResult AddPost() => View();

        [HttpPost]
        public async Task<ActionResult> AddPost(BlogPost post, IFormFile cover)
        {
            if (ModelState.IsValid)
            {
                string coverPath = "/images/BlogPosts/" + cover.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + coverPath, FileMode.Create))
                {
                    await cover.CopyToAsync(fileStream);
                }

                BlogPost posts = new BlogPost
                {
                    Name = post.Name,
                    ShortDesc = post.ShortDesc,
                    Desc = post.Desc,
                    Date = DateTime.Now.ToShortDateString(),
                    AddedBy = _userManager.GetUserAsync(User).Result.UserName,
                    CoverPath = coverPath
                };

                _db.BlogPosts.Add(posts);
                _db.SaveChanges();

                return RedirectToAction("Index", "Post");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditPost(int? id)
        {
            BlogPost post = await _db.BlogPosts.
                AsNoTracking().
                Where(x => x.Id == id).
                SingleOrDefaultAsync();

            if (post == null)
                return NotFound();

            var viewModel = new EditPostViewModel { EditPosts = post };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(EditPostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                BlogPost post = await _db.BlogPosts.
                    Where(x => x.Id == viewModel.EditPosts.Id).
                    FirstOrDefaultAsync();
                if (post == null)
                    return NotFound();

                post.Name = viewModel.EditPosts.Name;
                post.ShortDesc = viewModel.EditPosts.ShortDesc;
                post.Desc = viewModel.EditPosts.Desc;
                post.DateEdit = DateTime.Now.ToShortDateString();

                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "Post");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DelPost(int id)
        {
            BlogPost post = new BlogPost { Id = id };
            _db.Entry(post).State = EntityState.Deleted;
            _db.SaveChanges();

            return RedirectToAction("Index", "Post");
        }

        //секція користувачів
        [HttpGet]
        public IActionResult AddUser() => View();

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User 
                { 
                    Email = model.Users.Email, 
                    UserName = model.Users.UserName, 
                    Year = model.Users.Year,
                    Name = model.Users.Name,
                    SurName = model.Users.SurName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }



        //секція ролей
        [HttpGet]
        public IActionResult AddRole() => View();
        [HttpPost]
        public async Task<IActionResult> AddRole(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpGet]
        public IActionResult UserList() => View(_userManager.Users.ToList());
        [HttpGet]
        public async Task<IActionResult> ChangeRole(string userId)
        {
            // получаємо користувача
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получємо список ролей
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string userId, List<string> roles)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получємо список ролей користувача
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаєм всі ролі
                var allRoles = _roleManager.Roles.ToList();
                // получаємо список ролей, які додали
                var addedRoles = roles.Except(userRoles);
                // получаємо ролі, які були видалені
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}