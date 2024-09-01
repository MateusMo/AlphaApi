using Services.Domain;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace AlphaApi.Dto
{
    public class UpdateLinkTreeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(250)]
        [MinLength(25)]
        public string Description { get; set; }

        public static LinkTree ToDto(UpdateLinkDto Dto, LinkTree LinkTree)
        {
            LinkTree.Description = Dto.Description;
            LinkTree.Name = Dto.Name;
            return LinkTree;
        }
    }
}
