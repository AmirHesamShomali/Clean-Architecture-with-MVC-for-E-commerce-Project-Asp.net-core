using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Orders.Queries.IGetListOrder
{
    public interface IGetListOrders
    {
        List<Order> GetListorderservice();
    }

    public class GetListOrders : IGetListOrders
    {
        private readonly IDatabaseContext _context;
        public GetListOrders(IDatabaseContext context)
        {
            _context = context;
        }
        public List<Order> GetListorderservice()
        {
            return _context.Orders.ToList();
        }
    }
}
