using CarDIler.Data.Models;
using System.Collections.Generic;

namespace CarDIler.ViewModel
{
    public class BlogViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public PageViewModel PageViewModels { get; set; }
    }
}
