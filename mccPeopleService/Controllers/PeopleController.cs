using System.Collections.Generic;
using System.Threading.Tasks;
using mccPeopleService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mccPeopleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleContext _context;

        public PeopleController(PeopleContext context)
        {
            _context = context;
        }

        // GET: api/people
        // Get list of people.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        // GET: api/people/5
        // Get person by Id.
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {

                return NotFound();
            }

            return person;
        }

        // POST: api/people
        // Create new person.
        [HttpPost]
        public async Task<ActionResult<Person>> AddPesron(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddPesron), new
            {
                firstname = person.FirstName,
                lastname = person.LastName,
                nickname = person.Login,
                birthday = person.BirthDay,
                password = person.Password
            }, person);
        }

        // PUT: api/people/5
        // Make changes in person by Id.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(long id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/people/5
        // Remove person from list by Id.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(long id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
