using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practical1.Data;
using Practical1.Models;


namespace Practical1.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContext _context;

        public ProductController(AppDBContext context)
        {
            _context = context;
        }

        //GET: Fetch all product information
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Where(p => p.Discontinued == false)
                .ToListAsync();
            return View(products);
        }

        //GET: Fetch view used to create new Product record
        public async Task<IActionResult> Create()
        {
            ViewBag.SupplierList = new SelectList(await _context.Suppliers.ToListAsync(), "SupplierID", "CompanyName");
            return View();
        }

        //POST: Create new product record
        [HttpPost]
        public async Task<IActionResult> Create(Products product)
        {
            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes!");
            }
            return View(product);
        }

        //GET: Fetch specific product information for editing
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        //POST: Save edited record changes to db
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Products product)
        {
            if (id != product.SupplierID) return NotFound();

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.ProductID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return View(product);
        }

        // GET: Fetch product deletion view
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductID == id);

            if (product == null) return NotFound();

            return View(product);
        }

        //POST: Soft delete a product record
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> SoftDelete(int? id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.Discontinued = true;//soft delete by updating bool to true
                _context.Update(product);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
