
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data;


// Cette classe est une classe de contexte de base de données,
// elle permet de définir les tables de la base de données
public class ApplicationDbContext : DbContext
{
    // Nous allons creer un dbset pour chaque table
    // Dbset est une classe qui represente une table
    // Elle permet de faire le mapping entre la table et la classe C#
    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Student> Students { get; set; }


    // Constructeur de la classe
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}