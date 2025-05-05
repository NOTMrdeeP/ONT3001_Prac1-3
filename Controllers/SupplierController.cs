using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical1.Data;
using Practical1.Models;

namespace Practical1.Controllers
{
    public class SupplierController : Controller
    {
        private readonly AppDBContext _context;

        public SupplierController(AppDBContext context)
        {
            _context = context;
        }
        //GET: Retrieve list of all supplier records
        public async Task<IActionResult> Index()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            return View(suppliers);
        }

        //GET: Search for specific supplier by name
        public async Task<IActionResult> Search(string query)
        {
            var suppliers = await _context.Suppliers
                            .Where(p => p.CompanyName.Contains(query))
                            .ToListAsync();
            return View("Index", suppliers);
        }

        //GET: Fetch view used to create new Supplier record
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create new supplier record
        [HttpPost]
        public async Task<IActionResult> Create(Suppliers supplier)
        {
            try
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes!");
            }
            return View(supplier);
        }

        //GET: Fetch view used to Edit a supplier record
                //Supplier/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return NotFound();

            return View(supplier);
        }

        //POST: Save changes to Supplier entity
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Suppliers supplier)
        {
            if (id != supplier.SupplierID) return NotFound();

            try
            {
                _context.Update(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Suppliers.Any(p => p.SupplierID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return View(supplier);
        }
    }
}
