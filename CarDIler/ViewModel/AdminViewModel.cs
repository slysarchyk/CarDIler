using CarDIler.Data.Models.Car;
using CarDIler.Data.Models.User;
using System.Collections.Generic;

namespace CarDIler.ViewModel
{
    public class AdminViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<User> Users { get; set; }
        public int SSold { get; set; }
        public int SSoldOut { get; set; }
        public double SSPrice { get; set; }
        public double SSProfit { get; set; }

        public PageViewModel PageViewModels { get; set; }
    }
}
