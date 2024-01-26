using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

using WebEvidencPojistenychDK.Models;
using WebEvidencPojistenychDK.Data;

namespace WebEvidencPojistenychDK.Controllers
{
    public class InsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsurancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var insurances = await _context.Insurance.Include(i => i.InsuredPerson).ToListAsync();
            return View(insurances);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            var insurance = await _context.Insurance.Include(i => i.InsuredPerson).FirstOrDefaultAsync(m => m.Id == id);

            if (insurance == null)
            {
                return NotFound();
            }

            return View(insurance);
        }

        public IActionResult Create()
        {
            PopulateInsuredPeopleDropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InsuredPersonId,Type,Value")] Insurance insurance)
        {   
            
            
            _context.Add(insurance);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var insuredPeopleToEdit = await _context.Insurance.Include(i =>i.InsuredPerson).FirstOrDefaultAsync(m=>m.Id==id);

            var insurance = await _context.Insurance.FindAsync(id);
            
            if (insurance == null)
            {
                return NotFound();
            }

            var insuredPeopleFirstname = insuredPeopleToEdit.InsuredPerson?.FirstName;
            var insuredPeopleSurname = insuredPeopleToEdit.InsuredPerson?.Surname;
            return View(insurance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InsuredPersonId,Type,Value")] Insurance insurance)
        {
			if (id != insurance.Id)
			{
				return NotFound();
			}

			_context.Update(insurance);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceToDelete = await _context.Insurance
            .Include(m => m.InsuredPerson) // Include the related InsuredPerson
            .FirstOrDefaultAsync(m => m.Id == id);

            if (insuranceToDelete == null)
            {
                return NotFound();
            }



            // Retrieve additional data for display
            var insuredFirstName = insuranceToDelete.InsuredPerson?.FirstName;
            var insuredSurname = insuranceToDelete.InsuredPerson?.Surname;

            var insurance = await _context.Insurance.FirstOrDefaultAsync(m => m.Id == id);
            if (insurance == null)
            {
                return NotFound();
            }

            return View(insurance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            

            var insurance = await _context.Insurance.FindAsync(id);
            if (insurance != null)
            {
                _context.Insurance.Remove(insurance);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceExists(int? id)
        {
            return id != null && _context.Insurance.Any(e => e.Id == id);
        }

        private void PopulateInsuredPeopleDropdown()
        {
            var listOfInsured = _context.InsuredPerson
                .Select(person => new SelectListItem
                {
                    Text = $"{person.FirstName} {person.Surname}",
                    Value = person.Id.ToString()
                })
                .ToList();

            ViewBag.ListOfInsuredPeople = listOfInsured;
        }

    }
}