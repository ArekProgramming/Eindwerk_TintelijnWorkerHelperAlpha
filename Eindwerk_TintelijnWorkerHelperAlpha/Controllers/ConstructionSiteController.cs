using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eindwerk_TintelijnWorkerHelperAlpha.Models;

namespace Eindwerk_TintelijnWorkerHelperAlpha.Controllers
{
    public class ConstructionSiteController : Controller
    {
        private readonly AppDbContext _context;

        public ConstructionSiteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ConstructionSite
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ConstructionSites.Include(c => c.Address);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ConstructionSite/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructionSite = await _context.ConstructionSites
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.ConstructionSiteId == id);
            if (constructionSite == null)
            {
                return NotFound();
            }

            return View(constructionSite);
        }

        // GET: ConstructionSite/AddOrEdit          <- add
        // GET: ConstructionSite/AddOrEdit/id       <- edit
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ConstructionSite());
            }
            else
            {
                var constructionSite = await _context.ConstructionSites.FindAsync(id);
                if (constructionSite == null)
                {
                    return NotFound();
                }
                return View(constructionSite);
            }

               // ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", constructionSite.AddressId);
            //ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City");    <- ddl 
        }

               

        // POST: ConstructionSite/AddOrEdit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
                                                        // niet vergeten extra properties te binden hier!!!!                                                                   
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ConstructionSiteId,ClientName,IsActive,AddressId")] ConstructionSite constructionSite)
        {
            
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(constructionSite);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(constructionSite);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ConstructionSiteExists(constructionSite.ConstructionSiteId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                
                return Json(new {isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.ConstructionSites.ToList()) });
            }
            //ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", constructionSite.AddressId);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", constructionSite) });
        }

        // GET: ConstructionSite/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructionSite = await _context.ConstructionSites
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.ConstructionSiteId == id);
            if (constructionSite == null)
            {
                return NotFound();
            }

            return View(constructionSite);
        }

        // POST: ConstructionSite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var constructionSite = await _context.ConstructionSites.FindAsync(id);
            _context.ConstructionSites.Remove(constructionSite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConstructionSiteExists(int id)
        {
            return _context.ConstructionSites.Any(e => e.ConstructionSiteId == id);
        }
    }
}
