using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty(Name = "mess", SupportsGet = true)]
        public string mess { get; set; }

        public const string SessionKeyLogin = "_login";

        private readonly PizzaShopContext _context;

        public LoginModel(PizzaShopContext context)
        {
            _context = context;
        }

        public void OnGet(string mess)
        {
            this.mess = mess;
        }

        public IActionResult OnPost(string userName, string password)
        {
            var listAcc = _context.accounts.ToList();
            var listCus = _context.customers.ToList();

            userName = string.IsNullOrWhiteSpace(userName) ? "" : userName;
            password = string.IsNullOrWhiteSpace(password) ? "" : password;

            Account a = listAcc.FirstOrDefault(x =>
            x.username.ToLower().Equals(userName.ToLower()) &&
            x.password.Equals(password)
            );
            if (a == null)
            {
                Customers c = listCus.FirstOrDefault(x =>
               x.phone.ToLower().Equals(userName.ToLower()) &&
               x.password.Equals(password)
               );
                if(c != null)
                {
                    string json = JsonConvert.SerializeObject(c);
                    HttpContext.Session.SetString(SessionKeyLogin, json);
                    return RedirectToPage("/Index");
                }
                return RedirectToPage("/Login/Login", new { mess = "login fail" });
            }
            else
            {
                string json = JsonConvert.SerializeObject(a);
                HttpContext.Session.SetString(SessionKeyLogin, json);
                return RedirectToPage("/Index");
            }
        }

    }
}
