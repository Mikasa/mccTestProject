using mccTestProject.Models;
using mccTestProject.Context;
using System.Linq;

namespace mccTestProject.Data
{
    public class DbInitializer
    {
        public static void Initialize(PersonContext context)
        {
            context.Database.EnsureCreated();

            // Check for any people in DB.
            if (context.People.Any())
            {
                return;
            }

            // Initialize some people.
            var people = new Person[]
            {
                new Person
                {
                    FirstName = "Ivan",
                    Lastname = "Ivanoff",
                    Birthday = "23.03.1991",
                    Nickname = "Ivanko",
                    Password = "12345"
                },
                new Person
                {
                    FirstName = "Victor",
                    Lastname = "Smoke",
                    Birthday = "13.05.1992",
                    Nickname = "Smokie",
                    Password = "12345"
                }
            };

            // Add them to DB.
            foreach(Person person in people)
            {
                context.People.Add(person);
            }

            // Save DB state;
            context.SaveChanges();
        }



    }
}
