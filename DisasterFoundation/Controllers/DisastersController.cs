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
    public class DisastersController : Controller
    {
        private readonly appDbContext _context;

        public DisastersController()
        {
            _context = new appDbContext();
        }

        // GET: Disasters
        public async Task<IActionResult> Index()
        {
              return _context.Disasters != null ? 
                          View(await _context.Disasters.ToListAsync()) :
                          Problem("Entity set 'appDbContext.Disasters'  is null.");
        }


        // GET: Disasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Startdate,EndDate,Location,Disaster,RequiredAid")] Disasters disasters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disasters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disasters);
        }

        private bool DisastersExists(int id)
        {
          return (_context.Disasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
