using Services.Domain;
using System.ComponentModel.DataAnnotations;

namespace AlphaApi.Dto
{
    public class CreateLinkDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(250)]
        [MinLength(25)]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(2000)]
        [MinLength(3)]
        public string Url { get; set; }
        public bool Expires { get; set; } = false;
        public DateTime? ExpirationDate { get; set; }
        public bool HasPassword { get; set; } = false;
        public string Password { get; set; } = string.Empty;
        public bool HasMessage { get; set; } = false;
        public string Message { get; set; } = string.Empty;

        public static Link ToDto(CreateLinkDto createLinkDto)
        {
            return new Link()
            {
                UserId = createLinkDto.UserId,
                Name = createLinkDto.Name,
                Description = createLinkDto.Description,
                Url = createLinkDto.Url,
                Expires = createLinkDto.Expires,
                ExpirationDate = createLinkDto.ExpirationDate,
                HasMessage = createLinkDto.HasMessage,
                Message = createLinkDto.Message,
                HasPassword = createLinkDto.HasPassword,
                Password = createLinkDto.Password,
            };
        }
    }
}
