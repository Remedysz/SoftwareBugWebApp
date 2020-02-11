using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleMvcAP.Models;
using SampleMvcApp.Data;

namespace SampleMvcApp.Controllers
{
    public class BugModelsController : Controller
    {
        private readonly MyDbContext _context;

        public BugModelsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: BugModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SBDBTable.ToListAsync());
        }

        // GET: BugModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.SBDBTable
                .FirstOrDefaultAsync(m => m.BugID == id);
            if (bugModel == null)
            {
                return NotFound();
            }

            return View(bugModel);
        }

        // GET: BugModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BugModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BugID,BugTitle,BugDescription,SubmittedBy")] BugModel bugModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bugModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bugModel);
        }

        // GET: BugModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.SBDBTable.FindAsync(id);
            if (bugModel == null)
            {
                return NotFound();
            }
            return View(bugModel);
        }

        // POST: BugModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BugID,BugTitle,BugDescription,SubmittedBy")] BugModel bugModel)
        {
            if (id != bugModel.BugID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bugModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugModelExists(bugModel.BugID))
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
            return View(bugModel);
        }

        // GET: BugModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.SBDBTable
                .FirstOrDefaultAsync(m => m.BugID == id);
            if (bugModel == null)
            {
                return NotFound();
            }

            return View(bugModel);
        }
        public async Task<IActionResult> AdminIndex()
        {
            return View(await _context.SBDBTable.ToListAsync());
        }

        // POST: BugModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bugModel = await _context.SBDBTable.FindAsync(id);
            _context.SBDBTable.Remove(bugModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugModelExists(int id)
        {
            return _context.SBDBTable.Any(e => e.BugID == id);
        }
    }
}
