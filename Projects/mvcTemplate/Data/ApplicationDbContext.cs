
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data;


// Cette classe est une classe de contexte de base de données,
// elle permet de définir les tables de la base de données
public class ApplicationDbContext : IdentityDbContext<Teacher>
{
    // Nous allons creer un dbset pour chaque table
    // Dbset est une classe qui represente une table
    // Elle permet de faire le mapping entre la table et la classe C#
    // public DbSet<Teacher> Teachers { get; set; } on commente cette ligne car on a herité de IdentityDbContext<Teacher>
    // c'est maintenant IdentityDbContext qui s'occupe de la table Teacher

    public DbSet<Student> Students { get; set; }


    // Constructeur de la classe
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}