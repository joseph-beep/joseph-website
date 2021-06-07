using joseph_website.Data;
using joseph_website.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebsiteContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Persons.Any())
            {
                return;   // DB has been seeded
            }

            var persons = new Person[]
            {
                new Person {FirstName="Carson",LastName="Alexander",Age=10,IsDead="False",Description="Is cool."},
                new Person {FirstName="Meredith",LastName="Alonso",Age=10,IsDead="Almost",Description="Is cool."},
                new Person {FirstName="Arturo",LastName="Anand",Age=65,IsDead="False",Description="Is cool."},
                new Person {FirstName="Gytis",LastName="Barzdukas",Age=10,IsDead="False",Description="Is cool."},
                new Person {FirstName="Yan",LastName="Li",Age=65,IsDead="True",Description="Is cool."},
                new Person {FirstName="Peggy",LastName="Justice",Age=10,IsDead="False",Description="Is cool."},
                new Person {FirstName="Laura",LastName="Norman",Age=65,IsDead="Almost",Description="Is cool."},
                new Person {FirstName="Nino",LastName="Olivetto",Age=10,IsDead="True",Description="Is cool."}
            };
            foreach (Person s in persons)
            {
                context.Persons.Add(s);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order { Name = "Hello World 1", PersonID = 0 },
                new Order { Name = "Hello World 2", PersonID = 1 },
                new Order { Name = "Hello World 3", PersonID = 2 },
                new Order { Name = "Hello World 4", PersonID = 3 },
                new Order { Name = "Hello World 5", PersonID = 7 },
                new Order { Name = "Hello World 6", PersonID = 2 }
            };
            foreach (Order order in orders)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}