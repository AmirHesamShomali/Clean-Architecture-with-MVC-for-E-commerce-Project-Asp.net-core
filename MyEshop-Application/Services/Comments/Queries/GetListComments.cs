using MyEshop_Application.Interfaces.Contexts;

namespace MyEshop_Application.Services.Comments.Queries
{
    public class GetListComments : IGetListComments
    {
        private readonly IDatabaseContext _context;

        public GetListComments(IDatabaseContext context)
        {
              _context = context;
        }
        public ResaultComment GetlistCommentService()
        {
            var Comments=_context.Comments.ToList();

            return new ResaultComment()
            {
                Comments = Comments,
                Success = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
