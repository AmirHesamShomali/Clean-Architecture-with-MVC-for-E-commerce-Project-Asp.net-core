using MyEshop_Domain.Entities.Comment;

namespace MyEshop_Application.Services.Comments.Queries
{
    public class ResaultComment
    {
        public List<Comment> Comments { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
