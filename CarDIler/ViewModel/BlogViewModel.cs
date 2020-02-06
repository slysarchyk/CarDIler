using CarDIler.Data.Models.Post;
using System.Collections.Generic;

namespace CarDIler.ViewModel
{
    public class BlogViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public PageViewModel PageViewModels { get; set; }
    }
}
