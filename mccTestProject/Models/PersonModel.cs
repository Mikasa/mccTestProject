using System.ComponentModel.DataAnnotations.Schema;

namespace mccTestProject.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Birthday { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
