using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mccTestProjectRP.Models;

namespace mccTestProjectRP.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly PersonContext _context;

        public IndexModel(PersonContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Person.ToListAsync();
        }
    }
}
