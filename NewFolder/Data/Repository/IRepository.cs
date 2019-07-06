using Neupusti.Models;
using Neupusti.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neupusti.Data.Repository
{
    public interface IRepository
    {
        List<Post> GetPremiumPosts(string Premium);
        Post GetPost(int id);
        List<Post> GetAllPosts();
        List<Post> GetAllPosts(string Category);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        Task<bool> SaveChangesAsync();
    }
}
