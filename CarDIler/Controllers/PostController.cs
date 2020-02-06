using System.Linq;
using System.Threading.Tasks;
using CarDIler.Data.Models.Post;
using CarDIler.Models;
using CarDIler.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDIler.Controllers
{
    public class PostController : Controller
    {
        private SqlContext _db;
        public PostController(SqlContext context)
        {
            _db = context;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 3;

            IQueryable<Post> post = _db.Posts;
            var count = post.Count();

            PageViewModel pvm = new PageViewModel(page, pageSize, count);

            BlogViewModel bvw = new BlogViewModel
            {
                Posts = post.OrderByDescending(x => x.Id).
                    Skip((page - 1) * pageSize).
                    Take(pageSize).
                    ToList(),
                PageViewModels = pvm 
            };
            
            return View(bvw);
        }

        public async Task<IActionResult> DetalPost(int? id)
        {
            if(id != null)
            {
                var post = await _db.Posts.FirstOrDefaultAsync(x => x.Id == id);

                if (post == null)
                    return NotFound();
                DetalPostViewModel detalPost = new DetalPostViewModel
                {
                    Posts = post
                };
                return View(detalPost);
            }
            return NotFound();
        }
    }
}