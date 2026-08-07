using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Application.Interfaces.IFacedPattern;
using MyEshop_Application.Services.Products.Command.Addnewcategory;
using MyEshop_Application.Services.Products.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Products.FacedPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDatabaseContext _context;
        public ProductFacad(IDatabaseContext context)
        {
            _context = context;
        }

        private Addcategory _addcategory;
        public Addcategory Addcategory
        {
            get {
                return _addcategory = _addcategory ?? new Addcategory(_context);
            }
        }

        private GetCategories _GetCategories;

        public GetCategories GetCategories
        {
            get{
                return _GetCategories=_GetCategories ?? new GetCategories(_context);
            }
        }
    }
}
