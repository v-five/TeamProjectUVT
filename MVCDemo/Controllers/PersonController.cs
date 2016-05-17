using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Person(int id)
        {
            var context = new DemoContext();
            var person = context.Person.Include("BasicInfo").Include("ContactInfo").Include("ProfessionalInfo").Single(p => p.Id == id);

            return View(person);
        }
    }
}

