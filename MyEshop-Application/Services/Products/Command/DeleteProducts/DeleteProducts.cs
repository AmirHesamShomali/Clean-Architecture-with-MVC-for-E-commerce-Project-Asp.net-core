using MyEshop_Application.Interfaces.Contexts;

namespace MyEshop_Application.Services.Products.Command.AddProducts
{
    public class DeleteProducts : IDeleteProducts
    {
        private readonly IDatabaseContext _context;
        public DeleteProducts(IDatabaseContext context)
        {
            _context=context;
        }
        public ResaultDeleteProduct DeleteProductService(int product_id)
        {
            var products = _context.Products.FirstOrDefault(p => p.Id == product_id);
            _context.Products.Remove(products);
            _context.SaveChanges();
            return new ResaultDeleteProduct()
            {
                Success = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
