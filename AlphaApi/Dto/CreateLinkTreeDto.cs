using Services.Domain;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace AlphaApi.Dto
{
    public class CreateLinkTreeDto
    {

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(250)]
        [MinLength(25)]
        public string Description { get; set; }
        public int UserId { get; set; }

        public static LinkTree ToDto(CreateLinkTreeDto dto)
        {
            return new LinkTree()
            {
                Description = dto.Description,
                Name = dto.Name,
                UserId = dto.UserId,
            };
        }
    }
}
