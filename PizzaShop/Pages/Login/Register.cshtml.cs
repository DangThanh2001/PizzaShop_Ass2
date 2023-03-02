using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.Login
{
    public class RegisterModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;
        [BindProperty]
        public Customers customers { get; set; }

        public RegisterModel(PizzaShopContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            try
            {
                var c = _context.customers.FirstOrDefault(
                    x => x.phone == customers.phone && x.password == customers.password
                    );
                if( c != null )
                {
                    throw new Exception();
                }
                _context.customers.Add(customers);
                _context.SaveChanges();
                return RedirectToPage("/Login/Login");
            }catch(Exception ex)
            {
                return RedirectToPage();
            }
        }
    }
}
