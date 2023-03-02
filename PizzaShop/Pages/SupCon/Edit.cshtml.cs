using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.SupCon
{
    public class EditModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public EditModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Supply Supply { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.supplies == null)
            {
                return NotFound();
            }

            var supply =  await _context.supplies.FirstOrDefaultAsync(m => m.supplierId == id);
            if (supply == null)
            {
                return NotFound();
            }
            Supply = supply;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Supply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyExists(Supply.supplierId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SupplyExists(int id)
        {
          return _context.supplies.Any(e => e.supplierId == id);
        }
    }
}
