using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace joseph_website.Controllers.Database
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }

        public int Age { get; set; }
        public bool IsDead { get; set; }

        public Person(string firstName, string lastName, int age, bool isDead)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsDead = isDead;
        }
    }
}
