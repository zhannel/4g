using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Neupusti.Models;
using Neupusti.Models.Comments;

namespace Neupusti.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
           
        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.ToList();
        }

        public List<Post> GetPremiumPosts(string Premium)
        {

            return _ctx.Posts.Where(post => post.Premium.ToLower().Equals(Premium.ToLower()))
                .ToList();
        }

        public List<Post> GetAllPosts(string Category)
        {

            return _ctx.Posts.Where(post => post.Category.ToLower().Equals(Category.ToLower()))
                .ToList();
        }

        public Post GetPost(int id)
        {

            return _ctx.Posts.
                Include(p => p.Comments)
                .FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync()>0)
            {
                return true;
            }
            return false;
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }
    }
}
