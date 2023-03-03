﻿using System;
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
    public class TablasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TablasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tablas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tabla.ToListAsync());
        }

        // GET: Tablas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tabla == null)
            {
                return NotFound();
            }

            var tabla = await _context.Tabla
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabla == null)
            {
                return NotFound();
            }

            return View(tabla);
        }

        // GET: Tablas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tablas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,Activo,FechaRegistro")] Tabla tabla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabla);
        }

        // GET: Tablas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tabla == null)
            {
                return NotFound();
            }

            var tabla = await _context.Tabla.FindAsync(id);
            if (tabla == null)
            {
                return NotFound();
            }
            return View(tabla);
        }

        // POST: Tablas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,Activo,FechaRegistro")] Tabla tabla)
        {
            if (id != tabla.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaExists(tabla.Id))
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
            return View(tabla);
        }

        // GET: Tablas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tabla == null)
            {
                return NotFound();
            }

            var tabla = await _context.Tabla
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabla == null)
            {
                return NotFound();
            }

            return View(tabla);
        }

        // POST: Tablas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tabla == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tabla'  is null.");
            }
            var tabla = await _context.Tabla.FindAsync(id);
            if (tabla != null)
            {
                _context.Tabla.Remove(tabla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaExists(int id)
        {
          return _context.Tabla.Any(e => e.Id == id);
        }
    }
}
