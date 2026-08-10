using MyEshop_Application.Interfaces.Contexts;

namespace MyEshop_Application.Services.Comments.Commands
{
    public class DeleteComment : IDeleteComment
    {
        private readonly IDatabaseContext _context;

        public DeleteComment(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultCommentService DeleteCommentService(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);
            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return new ResaultCommentService()
            {
                Success = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
