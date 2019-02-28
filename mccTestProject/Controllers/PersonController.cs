using System;
using Microsoft.AspNetCore.Mvc;
using mccTestProject.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mccTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;

            if (_context.People.Count() == 0)
            {
                _context.People.Add(new Person
                {
                    Name = "Ivan",
                    Surname = "Ivanov",
                    Nickname = "Ivanich1991",
                    Birthday = DateTime.Now,
                    Password = "SuperPassword"
                });
                _context.SaveChanges();
            }

        }

        // GET: api/person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        // GET: api/person/1
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

        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerson), new
            {

                id = person.Id,
                name = person.Name,
                surname = person.Surname,
                nickname = person.Nickname,
                password = person.Password,
                birthdate = person.Birthday

            }, person);
        }

    }
}
