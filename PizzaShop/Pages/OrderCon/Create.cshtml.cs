using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.OrderCon
{
    public class CreateModel : PageModel
    {
        public List<Customers> listCus;
        private readonly PizzaShop.Data.PizzaShopContext _context;

        public CreateModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            listCus = _context.customers.ToList();
            return Page();
        }

        [BindProperty]
        public Orders Orders { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }
            listCus = _context.customers.ToList();
            var cus = listCus.FirstOrDefault(x => x.customerId == Orders.customerId);
            Orders.customers = cus;
            _context.orders.Add(Orders);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
