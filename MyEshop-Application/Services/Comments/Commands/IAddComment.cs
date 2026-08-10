using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Comments.Commands
{
    public interface IAddComment
    {
        ResaultAddComment AddCommentService(Comment comment);
    }

    public class AddComment : IAddComment
    {
        private readonly IDatabaseContext _context;

        public AddComment(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultAddComment AddCommentService(Comment requestcomment)
        {
            var NewComment = new Comment()
            {
                Description = requestcomment.Description,
                Name = requestcomment.Name
            };
            _context.Comments.Add(NewComment);
            _context.SaveChanges();
            return new ResaultAddComment()
            {
                comment = NewComment,
                Success = true,
                Message = "کامنت جدید اضاف شد"
            };

        }
    }

    public class ResaultAddComment
    {
        public Comment comment { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
