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
        public async Task<ActionResult<Link>> CreateLink([FromBody] CreateLinkDto Link)
        {
            var createdLink = await _LinkService.CreateLink(CreateLinkDto.ToDto(Link));
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
                return NotFound(new DefaultReturnDto<int>()
                {
                    Status = 404,
                    Message = "No link was found",
                    Data = 0
                });
            }
            return Ok(new DefaultReturnDto<Link>()
            {
                Status = 200,
                Message = "Link Found",
                Data = Link
            });
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Link>>> GetAllLinks()
        //{
        //    var Links = await _LinkService.GetAllLinks();
        //    return Ok(Links);
        //}

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<Link>> UpdateLink(int id, [FromBody] UpdateLinkDto LinkDto)
        {
            if (id != LinkDto.Id)
            {
                return BadRequest(new DefaultReturnDto<int>()
                {
                    Status = 401,
                    Message = "Bad Communication",
                    Data = 0
                });
            }

            var updatedLink = await _LinkService
                .UpdateLink(UpdateLinkDto.ToDto(LinkDto, await _LinkService.GetLinkById(id)));

            if (updatedLink == null)
            {
                return NotFound(new DefaultReturnDto<int>()
                {
                    Status = 404,
                    Message = "Not Found",
                    Data = 0
                });
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
