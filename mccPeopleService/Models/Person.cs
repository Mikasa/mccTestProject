using System;

namespace mccPeopleServiceAPI.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public DateTime BirthDay { get; set; }
    }
}