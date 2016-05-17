using MVCDemo.Models;
using System.Web.Mvc;
using Database;
using System.Linq;

namespace MVCDemo.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Person(int id)
        {
            var context = new DemoContext();
            var person = context.Person
                .Include("BasicInfo")
                .Include("ContactInfo")
                .Include("ProfessionalInfo")
                .SingleOrDefault(p => p.Id == id);

            return View(person);
        }



        public string DeletePerson(int id)
        {
            var context = new DemoContext();
            var itemToDelete = context.Person.Find(id);
            if (itemToDelete != null)
            {
                itemToDelete.IsDeleted = true;
                context.SaveChanges();
                string message = "204";
                return message;
            }
            else
            {
                string message = "404";
                return message;
            }
        }
    }
}

