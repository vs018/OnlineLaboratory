﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineLaboratory.Data;
using OnlineLaboratory.Models;

namespace OnlineLaboratory.Pages.TestViews
{
    public class DeleteModel : PageModel
    {
        private readonly OnlineLaboratory.Data.OnlineLaboratoryContext _context;

        public DeleteModel(OnlineLaboratory.Data.OnlineLaboratoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tests Tests { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tests = await _context.Tests.FirstOrDefaultAsync(m => m.Id == id);

            if (Tests == null)
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

            Tests = await _context.Tests.FindAsync(id);

            if (Tests != null)
            {
                _context.Tests.Remove(Tests);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
