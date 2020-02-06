using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarDIler.Models;
using CarDIler.Data.Models.Car;
using Microsoft.EntityFrameworkCore;
using CarDIler.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace CarDIler.Controllers
{
    public class HomeController : Controller
    {
        private readonly SqlContext _db;
        IWebHostEnvironment _appEnvironment;

        public HomeController(SqlContext context, IWebHostEnvironment appEnvironment)
        {
            _db = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index(int? brand, int? category, int? fuel, int? year, int page = 1)
        {
            int pageSize = 3;

            IQueryable<Car> car = _db.Cars.
                Include(b => b.Brand).
                Include(c => c.Category).
                Include(f => f.Fuel).
                Include(y => y.Year);

            if (brand != null && brand != 0)
            {
                car = car.Where(b => b.BrandId == brand);
            }
            if (category != null && category != 0)
            {
                car = car.Where(c => c.CatId == category);
            }
            if (fuel != null && fuel != 0)
            {
                car = car.Where(f => f.FuelId == fuel);
            }
            if (year != null && year != 0)
            {
                car = car.Where(y => y.YearId == year);
            }

            List<Brand> brands = _db.Brands.ToList();
            brands.Insert(0, new Brand { BrandName = "All", Id = 0 });

            List<Category> cats = _db.Categories.ToList();
            cats.Insert(0, new Category { CatName = "All", Id = 0 });

            List<Fuel> fuels = _db.Fuels.ToList();
            fuels.Insert(0, new Fuel { FuelName = "All", Id = 0 });

            List<Year> years = _db.Years.ToList();
            years.Insert(0, new Year { YearName = "All", Id = 0 });

            var count = car.Count();

            PageViewModel pvw = new PageViewModel(count, page, pageSize);

            HomeViewModel hvw = new HomeViewModel
            {
                Cars = car.Where(s => s.Sold == false).
                    OrderByDescending(x => x.Id).
                    Skip((page - 1) * pageSize).
                    Take(pageSize).
                    ToList(),
                PageViewModels = pvw,
                Brands = new SelectList(brands, "Id", "BrandName"),
                Categories = new SelectList(cats, "Id", "CatName"),
                Fuels = new SelectList(fuels, "Id", "FuelName"),
                Years = new SelectList(years, "Id", "YearName"),
                LastCar = _db.Cars.Where(s => s.Sold == false).OrderByDescending(x => x.Id).First(),
                AvalibleCar = _db.Cars.Count(x => x.Sold == false)
            };

            return View(hvw);
        }
        public async Task<IActionResult> DetalCar(int? id)
        {
            if (id != null)
            {
                var detalcar = await _db.Cars.
                    Where(s => s.Sold == false).
                    Include(b => b.Brand).
                    Include(c => c.Category).
                    Include(f => f.Fuel).
                    Include(y => y.Year).
                    FirstOrDefaultAsync(c => c.Id == id);

                if (detalcar == null)
                    return NotFound();

                DetalCarViewModel dcvw = new DetalCarViewModel
                {
                    DetalCars = detalcar
                };

                return View(dcvw);
            }
            return NotFound();
        }
    }
}
