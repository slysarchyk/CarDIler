using System;
using System.Collections.Generic;
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
        public IActionResult Index()
        {
            IQueryable<Post> post = _db.Posts;

            BlogViewModel bvw = new BlogViewModel
            {
                Posts = post.OrderByDescending(x => x.Id).ToList()
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