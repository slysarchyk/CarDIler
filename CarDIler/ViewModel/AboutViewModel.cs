using CarDIler.Data.Models.About;
using CarDIler.Data.Models.User;
using System;
using System.Collections.Generic;

namespace CarDIler.ViewModel
{
    public class AboutViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public About Abouts { get; set; }
    }
}
