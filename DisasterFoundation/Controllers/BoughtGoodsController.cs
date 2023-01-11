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
    public class BoughtGoodsController : Controller
    {
        private readonly appDbContext _context;

        public BoughtGoodsController()
        {
            _context = new appDbContext();
        }

        // GET: BoughtGoods
        public async Task<IActionResult> Index()
        {
              return _context.BoughtGoods != null ? 
                          View(await _context.BoughtGoods.ToListAsync()) :
                          Problem("Entity set 'appDbContext.BoughtGoods'  is null.");
        }


        // GET: BoughtGoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoughtGoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Disaster,Description,Amount")] BoughtGoods boughtGoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boughtGoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boughtGoods);
        }

        private bool BoughtGoodsExists(int id)
        {
          return (_context.BoughtGoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
