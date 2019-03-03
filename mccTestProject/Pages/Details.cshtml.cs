using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mccTestProject.Models;
using mccTestProject.Services;

namespace mccTestProject.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly mccTestProject.Services.PersonContext _context;

        public DetailsModel(mccTestProject.Services.PersonContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.People.FirstOrDefaultAsync(m => m.PersonId == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
