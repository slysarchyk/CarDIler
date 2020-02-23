using CarDIler.Data.Models.Car;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarDIler.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public SelectList Brands { get; set; }
        public int Year { get; set; }
        public PageViewModel PageViewModels { get; set; }
        public Car LastCar { get; set; }
        public int AvalibleCar { get; set; }
    }
}
