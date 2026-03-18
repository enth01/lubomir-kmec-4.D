namespace Common.Dto
{
    public class CommentDto
    {
        public Guid PublicId { get; set; }
        public Guid UserPublicId { get; set; }
        public Guid ProductPublicId { get; set; }
        public string Text { get; set; } = "";
    }
}