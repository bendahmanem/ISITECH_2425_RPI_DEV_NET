public class Maman
{
    public void FaireUnGateau()
    {
        Console.WriteLine("Mélanger les ingrédients");
        Console.WriteLine("Mettre au four");
        Console.WriteLine("Attendre 30 minutes");
        Console.WriteLine("Sortir le gâteau du four");
    }

    // constructor
    public Maman(string nom)
    {
        Console.WriteLine("Maman est là");
    }
}