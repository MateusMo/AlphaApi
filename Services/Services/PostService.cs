using Services.Domain;
using Services.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _PostRepository;

        public PostService(IPostRepository PostRepository)
        {
            _PostRepository = PostRepository;
        }

        // Create
        public async Task<Post> CreatePost(Post Post)
        {
            return await _PostRepository.Create(Post);
        }

        // Read
        public async Task<Post> GetPostById(int id)
        {
            return await _PostRepository.GetById(id);
        }

        // ReadAll
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _PostRepository.GetAll();
        }

        // Update
        public async Task<Post> UpdatePost(Post Post)
        {
            return await _PostRepository.Update(Post);
        }

        // Delete
        public async Task DeletePost(int id)
        {
            await _PostRepository.Deactivate(id);
        }
    }
}
