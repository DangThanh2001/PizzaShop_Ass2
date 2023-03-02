using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaShop.Data;
using PizzaShop.Entity;

namespace PizzaShop.Pages.ProductCon
{
    public class CreateModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;
        public List<Category> listCat;
        public List<Supply> listSup;

        public CreateModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["categoryId"] = new SelectList(_context.categories, "categoryId", "categoryId");
            ViewData["supplyId"] = new SelectList(_context.supplies, "supplierId", "supplierId");
            listCat = _context.categories.ToList();
            listSup = _context.supplies.ToList();
            return Page();
        }

        [BindProperty]
        public Products Products { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //  {
            //      listCat = _context.categories.ToList();
            //      listSup = _context.supplies.ToList();
            //      return Page();
            //  }
            if (string.IsNullOrEmpty(Products.productImage))
            {
                Products.productImage = "https://i.stack.imgur.com/V0Tjp.png";
            }
            _context.products.Add(Products);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
