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
    public class IndexModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public IndexModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.products != null)
            {
                Products = await _context.products
                .Include(p => p.categoriesId)
                .Include(p => p.suppliersId).ToListAsync();
            }
        }
    }
}
