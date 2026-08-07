using Microsoft.EntityFrameworkCore;
using MyEshop_Application.Interfaces.Contexts;

namespace MyEshop_Application.Services.Products.Queries.GetCategories
{
    public class GetCategories : IGetCategories
    {
        private readonly IDatabaseContext _context;

        public GetCategories(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultCategoriesService GetCategoriesService(int? parentid)
        {
            var categories = _context.Category
                .Include(p => p.ParentCategory)
                .Include(p => p.sub_categories)
                .Where(p => p.ParentCategory.Id == parentid)
                .ToList()
                .Select(p => new CategoriesDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    parentcategory = p.ParentCategory != null ? new ParentcategoryDto()
                    {
                        Id = p.ParentCategory.Id,
                        Name = p.ParentCategory.Name
                    }:null,
                    Haschild=p.sub_categories.Count() > 0?true:false
                }).ToList();

            return new ResaultCategoriesService()
            {
                Data = categories,
                Success = true,
                Message = "عملیات با موفقیت انجام شد"

            };
        }
    }

}
