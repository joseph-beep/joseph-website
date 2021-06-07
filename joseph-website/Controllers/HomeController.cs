using joseph_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace joseph_website.Controllers
{
    public class HomeController : Controller
    {
        ////private const string CONNECTION_STRING = "Server=172.16.160.21;Port=3306;Database=110737;Uid=lgg;Pwd=0P%Y9fI2GdO#;";
        //public const string CONNECTION_STRING = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110737;Uid=110737;Pwd=infsql2021;";

        private readonly ILogger<HomeController> _logger;
        private readonly Settings _settings;

        public HomeController(ILogger<HomeController> logger, IOptions<Settings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            List<Person> persons = GetPersons();

            return View(persons);
        }

        [Route("person/{id}")]
        public IActionResult Person(string id)
        {
            return View(GetPersons($"SELECT * FROM `persons` WHERE id = {id}")[0]);
        }

        public List<Person> GetPersons(string sqlCommand = "SELECT * FROM `persons`")
        {
            List<Person> persons = new List<Person>();

            //using (MySqlConnection conn = new MySqlConnection(_settings.ConnectionString))
            //{
            //    conn.Open();

            //    MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

            //    using (var reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            persons.Add(new Person(Convert.ToInt32(reader["id"]), reader["firstName"].ToString(), reader["lastName"].ToString(), Convert.ToInt32(reader["age"]), (string)reader["isDead"]));
            //        }
            //    }
            //}

            return persons;
        }

        public static ActionResult DoSomething()
        {
            string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110737;Uid=110737;Pwd=infsql2021;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand insertCommand = new MySqlCommand("INSERT INTO `persons` (`firstName`, `lastName`, `age`, `isDead`) VALUES ('Marcus', 'Aurelius', '999', '0');", conn);
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
