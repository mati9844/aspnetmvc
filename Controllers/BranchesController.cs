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
using Application.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Drawing.Printing;

namespace Application.Controllers
{
    [Authorize]
    public class BranchesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BranchesController(ApplicationContext context, UserManager<ApplicationUser> userMrg)
        {
            _context = context;
            _userManager = userMrg;

        }

        // GET: Branches
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Branch.Include(b => b.Voivodeship);
            return View(await applicationContext.ToListAsync());
        }
        public async Task<IActionResult> AdminIndex()
        {
            var applicationContext = _context.Branch.Include(b => b.Voivodeship);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Branches/Details/5
        [Authorize(Roles = "admin, Lider")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branch
                .Include(b => b.Voivodeship)
                .Include(i => i.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            var users = new List<ApplicationUser>();
            if (branch.ApplicationUsers == null)
            {
                branch.ApplicationUsers = new List<ApplicationUser>();
            }

            foreach (var user in branch.ApplicationUsers.ToList())
            {
                users.Add(user);

            }

            var voivodeship = branch.Voivodeship.Name;

            ViewBag.Users = users;
            ViewBag.Voivodeship = voivodeship;
            ViewBag.UserCount = users.Count();

            return View(branch);
        }

        // GET: Branches/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["VoivodeshipId"] = new SelectList(_context.Set<Voivodeship>(), "Id", "Id");
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,VoivodeshipId,Email,UrlFb")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                branch.ApplicationUsers = new List<ApplicationUser>();
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["VoivodeshipId"] = new SelectList(_context.Set<Voivodeship>(), "Id", "Id", branch.VoivodeshipId);
            return View(branch);
        }

        // GET: Branches/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            ViewData["VoivodeshipId"] = new SelectList(_context.Set<Voivodeship>(), "Id", "Id", branch.VoivodeshipId);
            return View(branch);
        }

        public async Task<IActionResult> Join(int? id)
        {
            System.Diagnostics.Debug.WriteLine("Start testu");
            if (id == null)
            {
                System.Diagnostics.Debug.WriteLine("error1");

                return NotFound();
            }

            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                System.Diagnostics.Debug.WriteLine("error2");
                return NotFound();
            }

            var _user = await _userManager.GetUserAsync(User);
            var users = new List<ApplicationUser>();
            if (branch.ApplicationUsers == null)
            {
                branch.ApplicationUsers = new List<ApplicationUser>();
            }
            if (!(branch.ApplicationUsers.Contains(_user))){
                System.Diagnostics.Debug.WriteLine("Dodany");
                branch.ApplicationUsers.Add(_user);
               // _context.Update(branch);
               // await _context.SaveChangesAsync();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("juz istnieje");
            }
            branch.ApplicationUsers.Add(_user);

            foreach (var user in branch.ApplicationUsers.ToList())
            {
                users.Add(user);

            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            _context.Entry(branch).State = EntityState.Modified;
            _context.SaveChanges();
            return View("Join");

        }
        // POST: Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,VoivodeshipId,Email,UrlFb")] Branch branch)
        {
            if (id != branch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branch.Id))
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
            ViewData["VoivodeshipId"] = new SelectList(_context.Set<Voivodeship>(), "Id", "Id", branch.VoivodeshipId);
            return View(branch);
        }

        // GET: Branches/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branch
                .Include(b => b.Voivodeship)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _context.Branch.FindAsync(id);
            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(int id)
        {
            return _context.Branch.Any(e => e.Id == id);
        }
    }
}
