using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.AccountCon
{
    public class IndexModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;
        public const string SessionKeyLogin = "_login";
        public Account acc { get; set; }
        public Customers cust { get; set; }

        public IndexModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyLogin)))
            {
                string json = HttpContext.Session.GetString(SessionKeyLogin);
                try
                {
                    acc = JsonConvert.DeserializeObject<Account>(json);
                }
                catch (Exception ex)
                {
                    cust = JsonConvert.DeserializeObject<Customers>(json);
                }
            }
            if (_context.accounts != null)
            {
                Account = await _context.accounts.ToListAsync();
            }
        }
    }
}
