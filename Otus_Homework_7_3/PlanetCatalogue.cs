namespace Otus_Homework_7_3;

public class PlanetCatalogue
{
    public const string RequestLimitErrorMessage = "Too frequent requests";
    private const string RequestNoResultMessage = "No such planet was found";
    public const string LimoniaRequestMessage = "This is forbidden planet";
    
    public delegate string? PlanetValidator(string name);
    
    private List<Planet> PlanetList { get; set; }

    public PlanetCatalogue()
    {
        InitializePlanetList();
    }

    private void InitializePlanetList()
    {
        var venus = new Planet("Venus", 2, 38025);
        var earth = new Planet("Earth", 3, 40075, venus);
        var mars = new Planet("Mars", 4, 21344, earth);
        
        PlanetList = new List<Planet> { venus, earth, mars };
    }

    public (int? order, int? equatorLength, string? errorText) GetPlanetInfo(string planetName, PlanetValidator validator)
    {
        var error = validator(planetName);
        if (error != null)
        {
            return SetErrorResponse(error);
        }
        
        var planet = GetPlanet(planetName);

        return planet == null 
            ? SetErrorResponse(RequestNoResultMessage) 
            : (planet.Order, planet.EquatorLength, null);
    }
    
    private (int?, int?, string?) SetErrorResponse(string errorMessage)
    {
        return (null, null, errorMessage);
    }
    
    private Planet? GetPlanet(string planetName)
    {
        return PlanetList.FirstOrDefault(p =>
            string.Equals(p.Name, planetName, StringComparison.CurrentCultureIgnoreCase));
    }
}