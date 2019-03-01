using System;
using System.Collections.Generic;
using mccTestProject.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace mccTestProject.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _people;

        public PersonService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("PeopleDB"));
            var database = client.GetDatabase("PeopleDB");
            _people = database.GetCollection<Person>("People");
        }

        // Get all people from DB.
        public List<Person> Get()
        {
            return _people.Find(person => true).ToList();
        }

        // Get person by ID.
        public Person Get(string id)
        {
            return _people.Find(person => person.Id == id).FirstOrDefault();
        }

        // Create new person.
        public Person Create(Person person)
        {
            _people.InsertOne(person);
            return person;
        }

        // Update person.
        public void Update(string id, Person personIn)
        {
            _people.ReplaceOne(person => person.Id == id, personIn);
        }

        // Delete person.
        public void Remove(string id)
        {
            _people.DeleteOne(person => person.Id == id);

        }

    }
}
