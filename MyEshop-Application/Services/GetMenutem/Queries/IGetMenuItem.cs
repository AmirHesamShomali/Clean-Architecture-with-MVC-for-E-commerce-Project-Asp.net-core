using Microsoft.EntityFrameworkCore;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.GetMenutem.Queries
{
    public interface IGetMenuItem
    {
		ResaultCategorieService GetMenuItems();
    }

	public class GetMenuItem : IGetMenuItem
	{
        private readonly IDatabaseContext _context;

        public GetMenuItem(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultCategorieService GetMenuItems()
		{
            var categories = _context.Category.Include(p => p.sub_categories).ToList()
                .Select(p => new MenuItemDto()
                {
                    CatId = p.Id,
                    Name = p.Name,
                    Childid = p.sub_categories.Select(p => new MenuItemDto()
                    {
                        CatId = p.Id,
                        Name = p.Name,

                    }).ToList()
                });
            return new ResaultCategorieService()
            {
                Success = true,
                Category = categories.ToList()
            };
		}
	}


    public class ResaultCategorieService()
    {
        public bool Success { get; set; }

        public List<MenuItemDto> Category { get; set; }
    }

	public class MenuItemDto
    {
        public string Name { get; set; }

        public int CatId { get; set; }

        public List<MenuItemDto> Childid { get; set; }
    }
}
