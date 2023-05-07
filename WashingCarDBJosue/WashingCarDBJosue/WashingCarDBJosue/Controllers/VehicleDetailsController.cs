using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WashingCarDBJosue.DAL;
using WashingCarDBJosue.DAL.Entities;

namespace WashingCarDBJosue.Controllers
{
    public class VehicleDetailsController : Controller
    {
        private readonly DatabaseContext _context;

        public VehicleDetailsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: VehicleDetails
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.VehiclesDetails.Include(v => v.Vehicle)
                .ThenInclude(s => s.Service);
            return View(await databaseContext.ToListAsync());
        }

        // GET: VehicleDetails/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.VehiclesDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehiclesDetails
                .Include(v => v.Vehicle)
                .ThenInclude(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Create
        public IActionResult Create()
        {
            ViewData["VehiculeId"] = new SelectList(_context.Vehicles, "Id", "NumberPlate");
            return View();
        }

        // POST: VehicleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleDetails vehicleDetails)
        {
            vehicleDetails.CreationDate = DateTime.Now;
            vehicleDetails.Id = Guid.NewGuid();
            _context.Add(vehicleDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["VehiculeId"] = new SelectList(_context.Vehicles, "Id", "NumberPlate", vehicleDetails.VehiculeId);
            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.VehiclesDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehiclesDetails.FindAsync(id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }
            ViewData["VehiculeId"] = new SelectList(_context.Vehicles, "Id", "NumberPlate", vehicleDetails.VehiculeId);
            return View(vehicleDetails);
        }

        // POST: VehicleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VehicleDetails vehicleDetails)
        {
            if (id != vehicleDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleDetailsExists(vehicleDetails.Id))
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
            ViewData["VehiculeId"] = new SelectList(_context.Vehicles, "Id", "NumberPlate", vehicleDetails.VehiculeId);
            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.VehiclesDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehiclesDetails
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // POST: VehicleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.VehiclesDetails == null)
            {
                return Problem("Entity set 'DatabaseContext.VehiclesDetails'  is null.");
            }
            var vehicleDetails = await _context.VehiclesDetails.FindAsync(id);
            if (vehicleDetails != null)
            {
                _context.VehiclesDetails.Remove(vehicleDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleDetailsExists(Guid id)
        {
          return (_context.VehiclesDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
