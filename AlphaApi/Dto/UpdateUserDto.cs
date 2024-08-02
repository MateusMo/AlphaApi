using Services.Domain;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace AlphaApi.Dto
{
    public class UpdateUserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [MaxLength(100, ErrorMessage = "The max length is 100 characters")]
        [MinLength(3, ErrorMessage = "The min length is 3 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [MaxLength(255, ErrorMessage = "The max length is 100 characters")]
        [MinLength(3, ErrorMessage = "The min length is 3 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [MaxLength(40, ErrorMessage = "The max length is 100 characters")]
        [MinLength(3, ErrorMessage = "The min length is 3 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public int Photo { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [MaxLength(20, ErrorMessage = "The max length is 20 characters")]
        [MinLength(3, ErrorMessage = "The min length is 3 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [MaxLength(250, ErrorMessage = "The max length is 250 characters")]
        [MinLength(25, ErrorMessage = "The min length is 25 characters")]
        public string Description { get; set; }

        public static User ToDto(UpdateUserDto userDto, User user)
        {
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.Description = userDto.Description;
            user.Photo = userDto.Photo;
            user.Title = userDto.Title;

            return user;
        }
    }
}
