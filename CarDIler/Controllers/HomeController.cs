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

        public HomeController(SqlContext context) {_db = context;}

        public IActionResult Index(int? brand, int page = 1)
        {
            int pageSize = 3;

            IQueryable<Car> queryable = _db.Cars.
                Include(b => b.Brand);

            if (brand != null && brand != 0)
            {
                queryable = queryable.Where(b => b.BrandId == brand);
            }

            List<Brand> brands = _db.Brands.ToList();
            brands.Insert(0, new Brand { BrandName = "All", Id = 0 });

            var count = queryable.Count();

            PageViewModel pvw = new PageViewModel(count, page, pageSize);

            HomeViewModel hvw = new HomeViewModel
            {
                Cars = queryable.Where(s => s.Sold == false).
                    OrderByDescending(x => x.Id).
                    Skip((page - 1) * pageSize).
                    Take(pageSize).
                    ToList(),
                PageViewModels = pvw,
                Brands = new SelectList(brands, "Id", "BrandName"),
                LastCar = _db.Cars.Where(s => s.Sold == false).OrderByDescending(x => x.Id).FirstOrDefault(),
                AvalibleCar = _db.Cars.AsTracking().Count(x => x.Sold == false)
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
                    AsNoTracking().
                    FirstOrDefaultAsync(c => c.Id == id);

                if (detalcar == null)
                    return NotFound();

                FullCarInfoViewModel dcvw = new FullCarInfoViewModel
                {
                    DetalCars = detalcar,
                    CarImages = _db.CarImages.Where(x => x.CarId == id).AsNoTracking()
                };

                return View(dcvw);
            }
            return NotFound();
        }
    }
}