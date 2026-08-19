using Microsoft.AspNetCore.Hosting;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Application.Interfaces.IFacedPattern;
using MyEshop_Application.Services.Products.Command.Addnewcategory;
using MyEshop_Application.Services.Products.Command.AddProduct;
using MyEshop_Application.Services.Products.Command.AddProducts;
using MyEshop_Application.Services.Products.Command.EditProduct;
using MyEshop_Application.Services.Products.Queries.GetCategories;
using MyEshop_Application.Services.Products.Queries.GetListProductFilters;
using MyEshop_Application.Services.Products.Queries.GetProducts;
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

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductFacad(IDatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
            get {
                return _GetCategories = _GetCategories ?? new GetCategories(_context);
            }
        }

        private GetListProducts _GetListProducts;

        public GetListProducts GetListProducts
        {
            get
            {
                return _GetListProducts = _GetListProducts ?? new GetListProducts(_context);
            }
        }

        private DeleteProducts _DeleteProducts;

        public DeleteProducts DeleteProducts
        {
            get
            {
                return (_DeleteProducts = _DeleteProducts ?? new DeleteProducts(_context));
            }
        }

        private AddProduct _AddProduct;

        public AddProduct Addproduct
        {
            get
            {
                return (_AddProduct = _AddProduct ?? new AddProduct(_context, _webHostEnvironment));
            }


        }

        private  EditProduct _Editproduct;
        public EditProduct Editproduct
        {
            get
            {
                return (_Editproduct = _Editproduct ?? new EditProduct(_context, _webHostEnvironment));
            }
        }

        private GetListProductFilter _GetListProductFilter;

        public GetListProductFilter GetListProductFilter
        {
            get
            {
                return(_GetListProductFilter=_GetListProductFilter ?? new GetListProductFilter(_context));  
            }
        }
    }
}
