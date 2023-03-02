using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.ProductCon
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public DetailsModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

      public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var products = await _context.products.FirstOrDefaultAsync(m => m.productId == id);
            if (products == null)
            {
                return NotFound();
            }
            else 
            {
                Products = products;
                ViewData["cat"] = _context.categories.FirstOrDefault(x => x.categoryId == products.categoryId).categoryName;
                ViewData["sup"] = _context.supplies.FirstOrDefault(x => x.supplierId == products.supplyId).companyName;
            }
            return Page();
        }
    }
}
