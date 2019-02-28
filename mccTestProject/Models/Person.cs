using System;
namespace mccTestProject.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
