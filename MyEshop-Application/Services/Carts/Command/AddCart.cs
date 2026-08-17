using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Cart;
namespace Services.Carts.Command
{
    public class AddCart : IAddCart
    {
        private readonly IDatabaseContext _context;

        public AddCart(IDatabaseContext context)
        {
            _context = context;
        }

        public ResaultCart AddCartService(int product_id, int quantity,string Emailuser)
        {
            var user=_context.Users.FirstOrDefault(u=>u.Email== Emailuser);
            var product = _context.Products.FirstOrDefault(p => p.Id == product_id);
            var cart = new Cart()
            {
                Name = product.Name,
                Price = product.Price*quantity,
                Count = quantity,
                Userid=user.Id
            };
            _context.Cart.Add(cart);
            _context.SaveChanges();
            return new ResaultCart()
            {
                Carts = cart,
                Success = true,
                Message = "عملیات با موفقیت انجام شد."
            };
        }

        public class ResaultCart
        {
            public bool Success { get; set; }

            public string Message { get; set; }

            public Cart Carts { get; set; }
        }

        public class CartViewModel
        {
            public string Name { get; set; }

            public int Count { get; set; }

            public float Price { get; set; }
        }
    }
}
