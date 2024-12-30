namespace Otus_Homework_7._2;

class Program
{
    static void Main(string[] args)
    {
        var planetList = new List<string>(){"Earth", "Limonia", "Mars", "Mars"};
        
        var catalog = new PlanetCatalogue();

        foreach (var planet in planetList)
        {
            var currentPlanet = catalog.GetPlanetInfo(planet);
            
            if (currentPlanet.errorText != null)
            {
                Console.WriteLine($"{planet}: {currentPlanet.errorText}");
            }
            else
            {
                Console.WriteLine($"{planet}:");
                Console.WriteLine($"Order: {currentPlanet.order}");
                Console.WriteLine($"Equator length: {currentPlanet.equatorLength}");
            }

            Console.WriteLine();
        }
        
        Console.ReadKey();
    }
}