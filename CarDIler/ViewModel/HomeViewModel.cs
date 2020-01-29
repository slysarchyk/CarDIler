using CarDIler.Data.Models.Car;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarDIler.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public SelectList Brands { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Fuels { get; set; }
        public SelectList Years { get; set; }
        public PageViewModel PageViewModels { get; set; }
        
        public Car LastCar { get; set; }
    }
}
