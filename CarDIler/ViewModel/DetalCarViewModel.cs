using CarDIler.Data.Models.Car;
using System.Collections.Generic;

namespace CarDIler.ViewModel
{
    public class DetalCarViewModel
    {
        public Car DetalCars { get; set; }
        public IEnumerable<Galery> Galerys { get; set; }
    }
}
