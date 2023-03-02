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
    public class DetailsModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public DetailsModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

      public Supply Supply { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.supplies == null)
            {
                return NotFound();
            }

            var supply = await _context.supplies.FirstOrDefaultAsync(m => m.supplierId == id);
            if (supply == null)
            {
                return NotFound();
            }
            else 
            {
                Supply = supply;
            }
            return Page();
        }
    }
}
