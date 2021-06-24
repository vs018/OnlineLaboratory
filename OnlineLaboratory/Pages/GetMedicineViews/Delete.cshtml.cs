using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineLaboratory.Data;
using OnlineLaboratory.Models;

namespace OnlineLaboratory.Pages.GetMedicineViews
{
    public class DeleteModel : PageModel
    {
        private readonly OnlineLaboratory.Data.OnlineLaboratoryContext _context;

        public DeleteModel(OnlineLaboratory.Data.OnlineLaboratoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GetMedicine GetMedicine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GetMedicine = await _context.GetMedicine.FirstOrDefaultAsync(m => m.id == id);

            if (GetMedicine == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GetMedicine = await _context.GetMedicine.FindAsync(id);

            if (GetMedicine != null)
            {
                _context.GetMedicine.Remove(GetMedicine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
