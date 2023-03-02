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
    public class DeleteModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public DeleteModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }
            var products = await _context.products.FindAsync(id);

            if (products != null)
            {
                Products = products;
                _context.products.Remove(Products);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
