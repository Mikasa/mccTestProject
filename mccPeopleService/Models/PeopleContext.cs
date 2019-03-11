using Microsoft.EntityFrameworkCore;

namespace mccPeopleServiceAPI.Models
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options)
            : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}
