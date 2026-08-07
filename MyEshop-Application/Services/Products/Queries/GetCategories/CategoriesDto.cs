namespace MyEshop_Application.Services.Products.Queries.GetCategories
{
    public class CategoriesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Haschild { get; set; }

        public ParentcategoryDto parentcategory { get; set; }
    }

}
