using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.CatCon
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public DetailsModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var category = await _context.categories.FirstOrDefaultAsync(m => m.categoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
