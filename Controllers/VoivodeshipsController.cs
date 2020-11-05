﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Application.Models;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    public class VoivodeshipsController : Controller
    {
        private readonly ApplicationContext _context;

        public VoivodeshipsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Voivodeships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voivodeship.ToListAsync());
        }

        // GET: Voivodeships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voivodeship = await _context.Voivodeship
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voivodeship == null)
            {
                return NotFound();
            }

            return View(voivodeship);
        }

        // GET: Voivodeships/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voivodeships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,Name")] Voivodeship voivodeship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voivodeship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voivodeship);
        }

        // GET: Voivodeships/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voivodeship = await _context.Voivodeship.FindAsync(id);
            if (voivodeship == null)
            {
                return NotFound();
            }
            return View(voivodeship);
        }

        // POST: Voivodeships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Voivodeship voivodeship)
        {
            if (id != voivodeship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voivodeship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoivodeshipExists(voivodeship.Id))
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
            return View(voivodeship);
        }

        // GET: Voivodeships/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voivodeship = await _context.Voivodeship
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voivodeship == null)
            {
                return NotFound();
            }

            return View(voivodeship);
        }

        // POST: Voivodeships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voivodeship = await _context.Voivodeship.FindAsync(id);
            _context.Voivodeship.Remove(voivodeship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoivodeshipExists(int id)
        {
            return _context.Voivodeship.Any(e => e.Id == id);
        }
    }
}
