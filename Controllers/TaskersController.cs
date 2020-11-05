using System;
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
    public class TaskersController : Controller
    {
        private readonly ApplicationContext _context;

        public TaskersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Taskers1
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Tasker.Include(t => t.ApplicationUser).Include(t => t.Task);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Taskers1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasker = await _context.Tasker
                .Include(t => t.ApplicationUser)
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasker == null)
            {
                return NotFound();
            }

            return View(tasker);
        }

        // GET: Taskers1/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["TaskId"] = new SelectList(_context.Task, "Id", "Id");
            return View();
        }

        // POST: Taskers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskId,ApplicationUserId,StartDate,EndDate")] Tasker tasker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", tasker.ApplicationUserId);
            ViewData["TaskId"] = new SelectList(_context.Task, "Id", "Id", tasker.TaskId);
            return View(tasker);
        }

        // GET: Taskers1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasker = await _context.Tasker.FindAsync(id);
            if (tasker == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", tasker.ApplicationUserId);
            ViewData["TaskId"] = new SelectList(_context.Task, "Id", "Id", tasker.TaskId);
            return View(tasker);
        }

        // POST: Taskers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskId,ApplicationUserId,StartDate,EndDate")] Tasker tasker)
        {
            if (id != tasker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskerExists(tasker.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", tasker.ApplicationUserId);
            ViewData["TaskId"] = new SelectList(_context.Task, "Id", "Id", tasker.TaskId);
            return View(tasker);
        }

        // GET: Taskers1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasker = await _context.Tasker
                .Include(t => t.ApplicationUser)
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasker == null)
            {
                return NotFound();
            }

            return View(tasker);
        }

        // POST: Taskers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasker = await _context.Tasker.FindAsync(id);
            _context.Tasker.Remove(tasker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskerExists(int id)
        {
            return _context.Tasker.Any(e => e.Id == id);
        }
    }
}