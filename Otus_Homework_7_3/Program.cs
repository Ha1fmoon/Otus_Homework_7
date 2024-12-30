namespace Otus_Homework_7_3;

class Program
{
    static void Main(string[] args)
    {
        var planetList = new List<string>(){"Earth", "Limonia", "Mars", "Mars", "Terra"};
        var counter = 0;
        
        var catalog = new PlanetCatalogue();

        foreach (var planet in planetList)
        {
            var currentPlanet = catalog.GetPlanetInfo(planet, name =>
            {
                counter++;
                
                if (counter % 3 == 0) return PlanetCatalogue.RequestLimitErrorMessage;
                
                return name == "Limonia" ? PlanetCatalogue.LimoniaRequestMessage : null;
            });
            
            if (currentPlanet.errorText != null)
            {
                PrintPlanetError(planet, currentPlanet.errorText);
            }
            else
            {
                PrintPlanetInfo(planet, currentPlanet.order, currentPlanet.equatorLength);
            }

            Console.WriteLine();
        }
        
        Console.ReadKey();
    }

    private static void PrintPlanetInfo(string planet, int? order, int? equatorLength)
    {
        Console.WriteLine($"{planet}:");
        Console.WriteLine($"Order: {order}");
        Console.WriteLine($"Equator length: {equatorLength}");
    }

    private static void PrintPlanetError(string planet, string errorText)
    {
        Console.WriteLine($"{planet}: {errorText}");
    }
}