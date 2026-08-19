using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Application.Services.Products.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Products.Queries.GetListProductFilters
{
    public interface IGetListProductFilter
    {
        ResaultProductService GetListProductFilterService(string SearchString);
    }

    public class GetListProductFilter : IGetListProductFilter
    {
        private readonly IDatabaseContext _context;

        public GetListProductFilter(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultProductService GetListProductFilterService(string SearchString)
        {
            if(string.IsNullOrEmpty(SearchString))
            {
                var products = _context.Products.ToList();
                return new ResaultProductService()
                {
                    Success = true,
                    Message = "با موفقیت انجام شد",
                    Products = products
                };
            }
            var product=_context.Products.Where(p=>p.Name.Contains(SearchString)).ToList();
            return new ResaultProductService()
            {
                Success = true,
                Message = "با موفقیت انجام شد",
                Products = product
            };
        }
    }
}
