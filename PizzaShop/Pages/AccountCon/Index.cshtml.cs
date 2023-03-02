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
    public class IndexModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public IndexModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.accounts != null)
            {
                Account = await _context.accounts.ToListAsync();
            }
        }
    }
}
