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
    public class DeleteModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public DeleteModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.supplies == null)
            {
                return NotFound();
            }
            var supply = await _context.supplies.FindAsync(id);

            if (supply != null)
            {
                Supply = supply;
                _context.supplies.Remove(Supply);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
