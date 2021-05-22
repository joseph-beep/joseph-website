using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace joseph_website.Controllers.Database
{
    public class Person
    {
        public int Id { get; }

        public string FirstName { get; }
        public string LastName { get; }

        public int Age { get; set; }
        public string IsDead { get; set; }

        public Person(int id, string firstName, string lastName, int age, string isDead)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsDead = isDead;
        }
    }
}
