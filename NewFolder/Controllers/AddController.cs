using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neupusti.Data.FileManager;
using Neupusti.Data.Repository;
using Neupusti.Models;
using Neupusti.ViewModels;

namespace Neupusti.Controllers
{
    [Authorize(Roles = "User")]
    public class AddController : Controller
    {

        private IRepository _repo;
        private IFileManager _fileManager;

        public AddController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new AddViewModel());
            }
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new AddViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body
                });
            }


        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body
            };
            
            if (post.Id > 0)
            {
                _repo.UpdatePost(post);
            }
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("/Home/Index");
            else
                return View(post);
        }
    }
}
