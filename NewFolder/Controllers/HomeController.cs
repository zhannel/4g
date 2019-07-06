using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neupusti.Data;
using Neupusti.Data.FileManager;
using Neupusti.Data.Repository;
using Neupusti.Models;
using Neupusti.Models.Comments;
using Neupusti.ViewModels;

namespace Neupusti.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public HomeController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;

        }

        public IActionResult Index(string Category)
        {
            var posts = string.IsNullOrEmpty(Category) ? _repo.GetAllPosts() : _repo.GetAllPosts(Category);
            return View(posts);
        }

        public IActionResult Premium (string Premium)
        {
            var posts = string.IsNullOrEmpty(Premium) ? _repo.GetAllPosts() : _repo.GetPremiumPosts(Premium);
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet("/Image/{image}")]
        [ResponseCache(CacheProfileName = "Monthly")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.')+1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { id = vm.PostId});
            var post = _repo.GetPost(vm.PostId);
            if(vm.Id > 0)
            {
                post.Comments = post.Comments ?? new List<Comment>();
                post.Comments.Add(new Comment
                {
                    Message = vm.Message,
                    Created = DateTime.Now
                });
                _repo.UpdatePost(post);
            }
           
            await _repo.SaveChangesAsync();

            return RedirectToAction("Post", new { id = vm.PostId });
        }
    }
}
