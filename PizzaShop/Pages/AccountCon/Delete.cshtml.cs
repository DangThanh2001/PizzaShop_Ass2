using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.AccountCon
{
    public class DeleteModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public DeleteModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.accounts == null)
            {
                return NotFound();
            }

            var account = await _context.accounts.FirstOrDefaultAsync(m => m.accountId == id);

            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.accounts == null)
            {
                return NotFound();
            }
            var account = await _context.accounts.FindAsync(id);

            if (account != null)
            {
                Account = account;
                _context.accounts.Remove(Account);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
