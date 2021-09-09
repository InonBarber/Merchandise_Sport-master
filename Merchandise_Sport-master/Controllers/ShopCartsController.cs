using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Merchandise_Sport_master.Data;
using Merchandise_Sport_master.Models;

namespace Merchandise_Sport_master.Controllers
{
    public class ShopCartsController : Controller
    {
        private readonly Merchandise_Sport_masterContext _context;

        public ShopCartsController(Merchandise_Sport_masterContext context)
        {
            _context = context;
        }

        // GET: ShopCarts
        public async Task<IActionResult> Index()
        {
            var merchandise_Sport_masterContext = _context.ShopCart.Include(s => s.User);
            return View(await merchandise_Sport_masterContext.ToListAsync());
        }

        // GET: ShopCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCart = await _context.ShopCart
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopCart == null)
            {
                return NotFound();
            }

            return View(shopCart);
        }

        // GET: ShopCarts/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password");
            return View();
        }

        // POST: ShopCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TotalPrice")] ShopCart shopCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", shopCart.UserId);
            return View(shopCart);
        }

        // GET: ShopCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCart = await _context.ShopCart.FindAsync(id);
            if (shopCart == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", shopCart.UserId);
            return View(shopCart);
        }

        // POST: ShopCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TotalPrice")] ShopCart shopCart)
        {
            if (id != shopCart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopCartExists(shopCart.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", shopCart.UserId);
            return View(shopCart);
        }

        // GET: ShopCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCart = await _context.ShopCart
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopCart == null)
            {
                return NotFound();
            }

            return View(shopCart);
        }

        // POST: ShopCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopCart = await _context.ShopCart.FindAsync(id);
            _context.ShopCart.Remove(shopCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopCartExists(int id)
        {
            return _context.ShopCart.Any(e => e.Id == id);
        }
    }
}
