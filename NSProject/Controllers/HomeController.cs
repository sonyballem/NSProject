using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NSProject.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NSProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Person> personList = new List<Person>();
            string NS = ConfigurationManager.ConnectionStrings["DBNS"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(NS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Person", connect);
                cmd.CommandType = CommandType.Text;
                connect.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var person = new Person();

                    person.personId = Convert.ToInt32(rdr["personId"]);
                    person.FirstName = rdr["FirstName"].ToString();
                    person.LastName = rdr["LastName"].ToString();
                    person.Email = rdr["Email"].ToString();
                    person.Gender = rdr["Gender"].ToString();
                    person.Age = Convert.ToInt32(rdr["Age"]);
                    person.Street = rdr["Street"].ToString();
                    person.City = rdr["City"].ToString();
                    person.State = rdr["State"].ToString();
                    person.Zip = Convert.ToInt32(rdr["Zip"]);
                    personList.Add(person);
                }
            }
            return View(personList);
        }
    }
}