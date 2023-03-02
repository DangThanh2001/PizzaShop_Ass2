using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.SupCon
{
    public class IndexModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public IndexModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        public IList<Supply> Supply { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.supplies != null)
            {
                Supply = await _context.supplies.ToListAsync();
            }
        }
    }
}
