using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Products;

namespace MyEshop_Application.Services.Products.Command.Addnewcategory
{
    public class Addcategory : IAddcategory
    {
        private readonly IDatabaseContext _context;

        public Addcategory(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultCategoryService Execute(int? Parentid, string Name)
        {
            if(Name==null)
            {
                return new ResaultCategoryService()
                {
                    Success = false,
                    Message = "نام دسته بندی رو ئارد کنید"
                };    
            }

            var NewCategory=new Category(); 
            NewCategory.Name = Name;    
            NewCategory.ParentCategory = GetParentCategory(Parentid);

            _context.Category.Add(NewCategory);
            _context.SaveChanges();
            return new ResaultCategoryService()
            {
                category = NewCategory,
                Success = true,
                Message = "عملیات با موفقیت انجام شد"

            };

        }

        private Category GetParentCategory(int? Parentid)
        {
            return _context.Category.Find(Parentid);
        }
    }
}
