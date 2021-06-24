﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLaboratory.Data;
using OnlineLaboratory.Models;

namespace OnlineLaboratory.Pages.TestViews
{
    public class EditModel : PageModel
    {
        private readonly OnlineLaboratory.Data.OnlineLaboratoryContext _context;

        public EditModel(OnlineLaboratory.Data.OnlineLaboratoryContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestsExists(Tests.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TestsExists(int id)
        {
            return _context.Tests.Any(e => e.Id == id);
        }
    }
}
