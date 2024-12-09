using Microsoft.AspNetCore.Mvc;

using mvc.Models;

public class TeacherController : Controller
{
    // liste d'enseignants
    private static List<Teacher> _teachers = new List<Teacher>
    {
        new Teacher { Id = 1, Lastname = "Doe", Firstname = "John" },
        new Teacher { Id = 2, Lastname = "Smith", Firstname = "Jane" }
    };


    public IActionResult Index()
    {
        return View(_teachers);
    }
}