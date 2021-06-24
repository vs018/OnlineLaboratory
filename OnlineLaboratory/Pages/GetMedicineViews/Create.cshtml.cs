using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLaboratory.Data;
using OnlineLaboratory.Models;

namespace OnlineLaboratory.Pages.GetMedicineViews
{
    public class CreateModel : PageModel
    {
        private readonly OnlineLaboratory.Data.OnlineLaboratoryContext _context;

        public CreateModel(OnlineLaboratory.Data.OnlineLaboratoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GetMedicine GetMedicine { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GetMedicine.Add(GetMedicine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
