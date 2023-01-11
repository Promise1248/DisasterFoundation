using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DisasterFoundation.Data;
using DisasterFoundation.Models;

namespace DisasterFoundation.Controllers
{
    public class DonationsController : Controller
    {
        private readonly appDbContext _context;

        public DonationsController()
        {
            _context = new appDbContext();
        }

        // GET: Donations
        public async Task<IActionResult> Index()
        {
              return _context.donations != null ? 
                          View(await _context.donations.ToListAsync()) :
                          Problem("Entity set 'appDbContext.donations'  is null.");
        }

        // GET: Donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.donations == null)
            {
                return NotFound();
            }

            var donations = await _context.donations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donations == null)
            {
                return NotFound();
            }

            return View(donations);
        }

        // GET: Donations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DonationDate,Donor,Category,Description,Amount")] Donations donations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donations);
        }

        private bool DonationsExists(int id)
        {
          return (_context.donations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
