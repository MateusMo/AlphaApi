using AlphaApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;
using Services.Services;

namespace AlphaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService _LinkService;

        public LinkController(ILinkService LinkService)
        {
            _LinkService = LinkService;
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<Link>> CreateLink([FromBody] Link Link)
        {
            var createdLink = await _LinkService.CreateLink(Link);
            return CreatedAtAction(nameof(GetLinkById), new { id = createdLink.Id }, new DefaultReturnDto<Link>()
            {
                Status = 200,
                Message = "Link successfuly created",
                Data = createdLink
            });
        }

        // Read
        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> GetLinkById(int id)
        {
            var Link = await _LinkService.GetLinkById(id);
            if (Link == null)
            {
                return NotFound();
            }
            return Ok(Link);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Link>>> GetAllLinks()
        //{
        //    var Links = await _LinkService.GetAllLinks();
        //    return Ok(Links);
        //}

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<Link>> UpdateLink(int id, [FromBody] Link Link)
        {
            if (id != Link.Id)
            {
                return BadRequest();
            }
            var updatedLink = await _LinkService.UpdateLink(Link);
            if (updatedLink == null)
            {
                return NotFound();
            }
            return Ok(new DefaultReturnDto<Link>()
            {
                Status = 200,
                Message = "Link successfuly updated",
                Data = updatedLink
            });
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            var Link = await _LinkService.GetLinkById(id);
            if (Link == null)
            {
                return NotFound();
            }
            await _LinkService.DeleteLink(id);
            return Ok(new DefaultReturnDto<Link>()
            {
                Status = 200,
                Message = "Link successfuly deleted",
                Data = Link
            });
        }
    }
}
