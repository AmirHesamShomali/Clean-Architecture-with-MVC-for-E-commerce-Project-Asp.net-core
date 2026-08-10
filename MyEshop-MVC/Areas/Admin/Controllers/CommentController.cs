using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Services.Comments.Commands;
using MyEshop_Application.Services.Comments.Queries;
using MyEshop_Domain.Entities.Comment;

namespace MyEshop_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CommentController : Controller
    {
        private readonly IGetListComments _GetListComments;

        private readonly IDeleteComment _deleteComment;

        private readonly IAddComment _addComment;

        public CommentController(IGetListComments GetListComments, IDeleteComment deleteComment, IAddComment addComment)
        {
            _GetListComments = GetListComments;
            _deleteComment=deleteComment;
            _addComment=addComment;
        }
        public IActionResult Index()
        {
            var resault = _GetListComments.GetlistCommentService();
            return View(resault.Comments);
        }

        public IActionResult AddComment() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(Comment requestcomment)
        {
            var resault=_addComment.AddCommentService(requestcomment);
            return Redirect("/admin/comment");
        }

        public IActionResult Delete(int comment_id)
        {
            _deleteComment.DeleteCommentService(comment_id);
            return Redirect("/admin/comment");
        }
    }
}
