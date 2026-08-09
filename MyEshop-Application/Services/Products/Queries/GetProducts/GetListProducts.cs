using MyEshop_Application.Interfaces.Contexts;

namespace MyEshop_Application.Services.Products.Queries.GetProducts
{
    public class GetListProducts : IGetListProducts
    {
        private readonly IDatabaseContext _context;

        public GetListProducts(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultProductService GetListProductService()
        {
            var products=_context.Products.ToList();
            return new ResaultProductService() {
                Products = products,
                Success = true,
                Message = "عملیات با موفقیت اضافه شد"
            };
        }
    }
}
