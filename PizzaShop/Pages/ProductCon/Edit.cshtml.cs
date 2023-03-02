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

namespace PizzaShop.Pages.ProductCon
{
    public class EditModel : PageModel
    {
        private readonly PizzaShop.Data.PizzaShopContext _context;
        public List<Category> listCat { get; set; }
        public List<Supply> listSup { get; set; }

        public EditModel(PizzaShop.Data.PizzaShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Products Products { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var products =  await _context.products.FirstOrDefaultAsync(m => m.productId == id);
            if (products == null)
            {
                return NotFound();
            }
            Products = products;
           ViewData["categoryId"] = new SelectList(_context.categories, "categoryId", "categoryId");
           ViewData["supplyId"] = new SelectList(_context.supplies, "supplierId", "supplierId");
            listCat = _context.categories.ToList();
            listSup = _context.supplies.ToList();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewData["categoryId"] = new SelectList(_context.categories, "categoryId", "categoryId");
            //    ViewData["supplyId"] = new SelectList(_context.supplies, "supplierId", "supplierId");
            //    return Page();
            //}

            _context.Attach(Products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(Products.productId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }

        private bool ProductsExists(int id)
        {
          return _context.products.Any(e => e.productId == id);
        }
    }
}
