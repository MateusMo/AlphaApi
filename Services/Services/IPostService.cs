using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IPostService
    {
        Task<Post> CreatePost(Post Post);
        Task<Post> GetPostById(int id);
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> UpdatePost(Post Post);
        Task DeletePost(int id);
    }
}
