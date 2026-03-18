using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class CommentCreateDto
    {
        [Required]
        public Guid UserPublicId { get; set; }
        [Required]
        public Guid ProductPublicId { get; set; }
        [Required]
        public required string Text { get; set; }
    }
}