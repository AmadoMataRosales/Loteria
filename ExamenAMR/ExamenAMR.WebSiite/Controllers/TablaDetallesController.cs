using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenAMR.WebSiite.Data;
using ExamenAMR.WebSite.Models;

namespace ExamenAMR.WebSite.Controllers
{
    public class TablaDetallesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TablaDetallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TablaDetalles
        public async Task<IActionResult> Index()
        {
              return View(await _context.TablaDetalle.ToListAsync());
        }

        // GET: TablaDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TablaDetalle == null)
            {
                return NotFound();
            }

            var tablaDetalle = await _context.TablaDetalle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaDetalle == null)
            {
                return NotFound();
            }

            return View(tablaDetalle);
        }

        // GET: TablaDetalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablaDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTabla,IdCarta")] TablaDetalle tablaDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaDetalle);
        }

        // GET: TablaDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TablaDetalle == null)
            {
                return NotFound();
            }

            var tablaDetalle = await _context.TablaDetalle.FindAsync(id);
            if (tablaDetalle == null)
            {
                return NotFound();
            }
            return View(tablaDetalle);
        }

        // POST: TablaDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTabla,IdCarta")] TablaDetalle tablaDetalle)
        {
            if (id != tablaDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaDetalleExists(tablaDetalle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tablaDetalle);
        }

        // GET: TablaDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TablaDetalle == null)
            {
                return NotFound();
            }

            var tablaDetalle = await _context.TablaDetalle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablaDetalle == null)
            {
                return NotFound();
            }

            return View(tablaDetalle);
        }

        // POST: TablaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TablaDetalle == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TablaDetalle'  is null.");
            }
            var tablaDetalle = await _context.TablaDetalle.FindAsync(id);
            if (tablaDetalle != null)
            {
                _context.TablaDetalle.Remove(tablaDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaDetalleExists(int id)
        {
          return _context.TablaDetalle.Any(e => e.Id == id);
        }
    }
}
