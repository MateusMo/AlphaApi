using Services.Domain;

namespace AlphaApi.Dto
{
    public class CreatePostDto
    {
        public int UserId { get; set; }
        public int? LinkId { get; set; }
        public int? LinkTreeId { get; set; }

        public static Post ToDto(CreatePostDto dto)
        {
            return new Post()
            {
                UserId = dto.UserId,
                LinkId = dto.LinkId,
                LinkTreeId = dto.LinkTreeId,
            };
        }
    }
}
