using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;

public class TeacherController : Controller
{
    // champ prive pour stocker le dbcontext
    private readonly ApplicationDbContext _context;

    // liste d'enseignants
    private static List<Teacher> _teachers = new List<Teacher>
    {
        new Teacher { Id = 1, Lastname = "Doe", Firstname = "John" },
        new Teacher { Id = 2, Lastname = "Smith", Firstname = "Jane" }
    };

    // Constructeur
    public TeacherController(ApplicationDbContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        return View(_teachers);
    }

    // Ecrire une liste d'Actions


    // Ajouter un Teacher
    // Accessible via /Teacher/Add en GET affichera le formulaire
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    // Accessible via /Teacher/Add en POST ajoutera le teacher
    [HttpPost]
    public IActionResult Add(Teacher teacher)
    {
        // Declencher le mecanisme de validation
        if (!ModelState.IsValid)
        {
            return View();
        }
        // Ajouter le teacher
        _context.Teachers.Add(teacher);

        // Sauvegarder les changements
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // Supprimer un Teacher

    // Afficher le détail d'un teacher
    // Accessible via /Teacher/ShowDetails/10
    public IActionResult ShowDetails(int id)
    {
        var teacher = _context.Teachers.Find(id);
        return View(teacher);
    }

    // Afficher tous les Teachers

}