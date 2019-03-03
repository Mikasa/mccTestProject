using System;
using System.ComponentModel.DataAnnotations;

namespace mccTestProjectRP.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public string Password { get; set; }
    }
}
