using AlphaApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;
using Services.Services;

namespace AlphaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _PostService;

        public PostController(IPostService PostService)
        {
            _PostService = PostService;
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost([FromBody] Post Post)
        {
            var createdPost = await _PostService.CreatePost(Post);
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, new DefaultReturnDto<Post>()
            {
                Status = 200,
                Message = "Post successfuly created",
                Data = createdPost
            });
        }

        // Read
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var Post = await _PostService.GetPostById(id);
            if (Post == null)
            {
                return NotFound();
            }
            return Ok(Post);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        //{
        //    var Posts = await _PostService.GetAllPosts();
        //    return Ok(Posts);
        //}

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, [FromBody] Post Post)
        {
            if (id != Post.Id)
            {
                return BadRequest();
            }
            var updatedPost = await _PostService.UpdatePost(Post);
            if (updatedPost == null)
            {
                return NotFound();
            }
            return Ok(new DefaultReturnDto<Post>()
            {
                Status = 200,
                Message = "Post successfuly updated",
                Data = updatedPost
            });
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var Post = await _PostService.GetPostById(id);
            if (Post == null)
            {
                return NotFound();
            }
            await _PostService.DeletePost(id);
            return Ok(new DefaultReturnDto<Post>()
            {
                Status = 200,
                Message = "Post successfuly deleted",
                Data = Post
            });
        }
    }
}
