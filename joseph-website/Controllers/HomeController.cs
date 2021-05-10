using joseph_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using joseph_website.Controllers.Database;

namespace joseph_website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Person> persons = GetPersons();

            return View(persons);
        }

        public List<Person> GetPersons()
        {
            // stel in waar de database gevonden kan worden
            //string connectionString = "Server=172.16.160.21;Port=3306;Database=110737;Uid=lgg;Pwd=0P%Y9fI2GdO#;";
            string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110737;Uid=110737;Pwd=infsql2021;";

            // maak een lege lijst waar we de namen in gaan opslaan
            List<Person> persons = new List<Person>();

            // verbinding maken met de database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // verbinding openen
                conn.Open();

                MySqlCommand insertCommand = new MySqlCommand("INSERT INTO `test-table` (`firstName`, `lastName`, `age`, `isDead`) VALUES ('Julius', 'Caesar', '400', '1');", conn);
                insertCommand.ExecuteNonQuery();

                // SQL query die we willen uitvoeren
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `test-table`", conn);

                // resultaat van de query lezen
                using (var reader = cmd.ExecuteReader())
                {
                    // elke keer een regel (of eigenlijk: database rij) lezen
                    while (reader.Read())
                    {
                        // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                        Person currentPerson = new Person(reader["firstName"].ToString(), reader["lastName"].ToString(), Convert.ToInt32(reader["age"]), (bool)reader["isDead"]);

                        // voeg de naam toe aan de lijst met namen
                        persons.Add(currentPerson);
                    }
                }
            }

            // return de lijst met namen
            return persons;
        }

        public static ActionResult DoSomething()
        {
            string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110737;Uid=110737;Pwd=infsql2021;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand insertCommand = new MySqlCommand("INSERT INTO `test-table` (`firstName`, `lastName`, `age`, `isDead`) VALUES ('Marcus', 'Aurelius', '999', '0');", conn);
                insertCommand.ExecuteNonQuery();
            }

            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(User user)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/success");
            }
            else
            {
                return View(user);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
