using Services.Domain;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace AlphaApi.Dto
{
    public class UpdateLinkDto
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

        public static Link ToDto(UpdateLinkDto updateLinkDto,Link link)
        {
            link.Name = updateLinkDto.Name;
            link.Description = updateLinkDto.Description;
            link.Url = updateLinkDto.Url;
            link.HasMessage = updateLinkDto.HasMessage;
            link.HasPassword = updateLinkDto.HasPassword;
            link.Expires = updateLinkDto.Expires;
            link.Message = updateLinkDto.Message;
            link.Password = updateLinkDto.Password;
            link.ExpirationDate = updateLinkDto.ExpirationDate;
            return link;
        }
    }
}
