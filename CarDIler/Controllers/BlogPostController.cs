using System.Linq;
using System.Threading.Tasks;
using CarDIler.Models;
using CarDIler.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDIler.Controllers
{
    public class BlogPostController : Controller
    {
        private SqlContext _db;
        public BlogPostController(SqlContext context)
        {
            _db = context;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 6;

            var allpost = _db.BlogPosts;

            var count = allpost.Count();

            PageViewModel pvm = new PageViewModel(page, pageSize, count);

            BlogViewModel bvw = new BlogViewModel
            {
                BlogPosts = allpost.OrderByDescending(x => x.Id).
                    Skip((page - 1) * pageSize).
                    Take(pageSize).
                    ToList(),
                PageViewModels = pvm
            };

            return View(bvw);
        }

        public async Task<IActionResult> FullPost(int? id)
        {
            if (id != null)
            {
                var post = await _db.BlogPosts.AsNoTracking().
                    FirstOrDefaultAsync(x => x.Id == id);

                if (post == null)
                    return NotFound();
                FullPostViewModel fpvw = new FullPostViewModel
                {
                    Posts = post
                };
                return View(fpvw);
            }
            return NotFound();
        }
    }
}