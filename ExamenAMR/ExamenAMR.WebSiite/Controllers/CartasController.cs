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
    public class CartasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cartas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Carta.ToListAsync());
        }

        // GET: Cartas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carta == null)
            {
                return NotFound();
            }

            var carta = await _context.Carta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // GET: Cartas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Imagen")] Carta carta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carta);
        }

        // GET: Cartas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carta == null)
            {
                return NotFound();
            }

            var carta = await _context.Carta.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }
            return View(carta);
        }

        // POST: Cartas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Imagen")] Carta carta)
        {
            if (id != carta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaExists(carta.Id))
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
            return View(carta);
        }

        // GET: Cartas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carta == null)
            {
                return NotFound();
            }

            var carta = await _context.Carta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // POST: Cartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Carta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Carta'  is null.");
            }
            var carta = await _context.Carta.FindAsync(id);
            if (carta != null)
            {
                _context.Carta.Remove(carta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaExists(int? id)
        {
          return _context.Carta.Any(e => e.Id == id);
        }
    }
}
