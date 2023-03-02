using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaShop.Entity;

namespace PizzaShop.Pages
{
    public class IndexModel : PageModel
    {
        public string searchName { get; set; }
        private readonly PizzaShop.Data.PizzaShopContext _context;
        private readonly ILogger<IndexModel> _logger;
        public const string SessionKeyLogin = "_login";
        public Account acc { get; set; }
        public Customers cust { get; set; }

        public IndexModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get; set; } = default!;

        public async Task OnGetAsync(string searchName)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyLogin)))
            {
                string json = HttpContext.Session.GetString(SessionKeyLogin);
                try
                {
                    acc = JsonConvert.DeserializeObject<Account>(json);
                }catch(Exception ex)
                {
                    cust = JsonConvert.DeserializeObject<Customers>(json);
                }
            }

            if (_context.products != null)
            {
                Products = await _context.products
                .Include(p => p.categoriesId)
                .Include(p => p.suppliersId).ToListAsync();
            }
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                this.searchName = searchName;
                Products = Products.Where(x => x.productName.ToLower().Contains(
                    searchName.Trim().ToLower()
                    )).ToList();
            }
        }
    }
}