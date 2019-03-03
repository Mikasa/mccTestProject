using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mccTestProject.Models;
using mccTestProject.Services;

namespace mccTestProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PersonContext _context;

        public IndexModel(PersonContext context)
        {
            _context = context;
        }

        public IList<Person> People { get;set; }

        public async Task OnGetAsync()
        {
            People = await _context.People.ToListAsync();
        }
    }
}
