using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace mccPeopleServiceAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleContext(
                serviceProvider.GetRequiredService<DbContextOptions<PeopleContext>>()))
            {
                // Look for any Person.
                if (context.People.Any()) return;

                // Add some people if DB is empty.
                for (var i = 0; i < 10; i++)
                    context.People.Add(new Person
                    {
                        FirstName = "User" + i,
                        LastName = "Lastname" + i,
                        BirthDay = DateTime.Now,
                        Login = "Login" + i,
                        Password = "Password" + i
                    });

                context.SaveChanges();
            }
        }
    }
}