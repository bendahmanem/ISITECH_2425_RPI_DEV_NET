public class Enfant : Maman
{
    public void Jouer()
    {
        Console.WriteLine("Je joue");
    }

    // constructor
    public Enfant(string nom) : base(nom)
    {
        Console.WriteLine("Enfant est là");
    }
}