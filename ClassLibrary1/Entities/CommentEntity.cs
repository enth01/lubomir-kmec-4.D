namespace ClassLibrary1.Entities
{
    public class CommentEntity : BaseEntity
    {
        public int UserId { get; set; }
        public required UserEntity User { get; set; }
        public int ProductId { get; set; }
        public required ProductEntity Product { get; set; }
        public required string Text { get; set; }
    }
}