using AlphaApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;
using Services.Services;

namespace AlphaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkTreeController : ControllerBase
    {
        private readonly ILinkTreeService _LinkTreeService;

        public LinkTreeController(ILinkTreeService LinkTreeService)
        {
            _LinkTreeService = LinkTreeService;
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<LinkTree>> CreateLinkTree([FromBody] CreateLinkTreeDto LinkTreeDto)
        {
            var createdLinkTree = await _LinkTreeService.CreateLinkTree(CreateLinkTreeDto.ToDto(LinkTreeDto));
            return CreatedAtAction(nameof(GetLinkTreeById), new { id = createdLinkTree.Id }, new DefaultReturnDto<LinkTree>()
            {
                Status = 200,
                Message = "LinkTree successfuly created",
                Data = createdLinkTree
            });
        }

        // Read
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkTree>> GetLinkTreeById(int id)
        {
            var LinkTree = await _LinkTreeService.GetLinkTreeById(id);
            if (LinkTree == null)
            {
                return NotFound();
            }
            return Ok(LinkTree);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<LinkTree>>> GetAllLinkTrees()
        //{
        //    var LinkTrees = await _LinkTreeService.GetAllLinkTrees();
        //    return Ok(LinkTrees);
        //}

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<LinkTree>> UpdateLinkTree(int id, [FromBody] UpdateLinkDto LinkTreeDto)
        {
            if (id != LinkTreeDto.Id)
            {
                return BadRequest(new DefaultReturnDto<int>()
                {
                    Status = 401,
                    Message = "Bad Communication",
                    Data = 0
                });
            }
            
            var linkTree = await _LinkTreeService.GetLinkTreeById(id);
            var updatedLinkTree = await _LinkTreeService.UpdateLinkTree(UpdateLinkTreeDto.ToDto(LinkTreeDto,linkTree));
            if (updatedLinkTree == null)
            {
                return NotFound(new DefaultReturnDto<int>()
                {
                    Status = 404,
                    Message = "Not Found",
                    Data = 0
                });
            }
            return Ok(new DefaultReturnDto<LinkTree>()
            {
                Status = 200,
                Message = "LinkTree successfuly updated",
                Data = updatedLinkTree
            });
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinkTree(int id)
        {
            var LinkTree = await _LinkTreeService.GetLinkTreeById(id);
            if (LinkTree == null)
            {
                return NotFound();
            }
            await _LinkTreeService.DeleteLinkTree(id);
            return Ok(new DefaultReturnDto<LinkTree>()
            {
                Status = 200,
                Message = "LinkTree successfuly deleted",
                Data = LinkTree
            });
        }
    }
}
