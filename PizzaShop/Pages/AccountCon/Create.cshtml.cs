using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.AccountCon
{
    public class CreateModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public CreateModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var acc = new Account();
            acc.username = Account.username;
            acc.password = Account.password;
            acc.fullname = Account.fullname;
            acc.type = 2;
            _context.accounts.Add(acc);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
