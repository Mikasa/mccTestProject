using mccTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace mccTestProject.Context
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        // Get all people from DB.
        public void Get()
        {
        }

        // Get person by ID.
        public void Get(string id)
        {
        }

        // Create new person.
        public void Create(Person person)
        {
        }

        // Update person.
        public void Update(string id, Person personIn)
        {
        }

        // Delete person.
        public void Remove(string id)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
