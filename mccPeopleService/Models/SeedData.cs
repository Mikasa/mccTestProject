using mccPeopleService;
using mccPeopleService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace mccPeopleServiceAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<PeopleContext>>()))
            {
                // Look for any Person.
                if (context.People.Any())
                {
                    return;
                }

                // Add some people if DB is empty.
                context.People.AddRange(
                    new Person
                    {
                        FirstName = "Sergey",
                        LastName = "Pushnoy",
                        BirthDay = DateTime.Now,
                        Login = "P00h",
                        Password = "P4sw0rd"
                    },
                    new Person
                    {
                        FirstName = "Margo",
                        LastName = "Veselaya",
                        BirthDay = DateTime.Now,
                        Login = "Margaritka",
                        Password = "P4sw0rd"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
