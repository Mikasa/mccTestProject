using System;
using Microsoft.AspNetCore.Mvc;
using mccTestProject.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mccTestProject.Services;

namespace mccTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        // GET: api/person
        [HttpGet]
        public ActionResult<List<Person>> GetPeople()
        {
            return _personService.Get();
        }

        // GET: api/person/1
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(string id)
        {
            var person = _personService.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // POST: api/person
        [HttpPost]
        public ActionResult<Person> CreatePerson(Person person)
        {
            _personService.Create(person);

            return CreatedAtAction(nameof(CreatePerson), new
            {

                id = person.Id,
                name = person.Name,
                surname = person.Surname,
                nickname = person.Nickname,
                password = person.Password,
                birthdate = person.Birthday

            }, person);
        }

        // PUT: api/person/1
        [HttpPut("{id}")]
        public IActionResult UpdatePerson(string id, Person personIn)
        {
            var person = _personService.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            _personService.Update(id, personIn);

            return NoContent();
        }

        // DELETE: api/person/1
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(string id)
        {
            var person = _personService.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            _personService.Remove(person.Id);

            return NoContent();

        }
    }
}
