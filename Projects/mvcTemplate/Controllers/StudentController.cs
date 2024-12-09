using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        // Creation d'une liste statique de Student
        private static List<Student> students = new()
        {
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
        };
        // GET: StudentController
        public ActionResult Index()
        {
            return View(students);
        }

    }
}
