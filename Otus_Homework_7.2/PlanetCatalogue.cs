namespace Otus_Homework_7._2;

public class PlanetCatalogue
{
    private int _requestCounter;
    
    private const string RequestLimitErrorMessage = "Too many requests";
    private const string RequestNoResultMessage = "No such planet was found";
    
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

    public (int? order, int? equatorLength, string? errorText) GetPlanetInfo(string planetName)
    {
        _requestCounter++;

        if (TooFrequentRequest()) return SetErrorResponse(RequestLimitErrorMessage);
        
        var planet = GetPlanet(planetName);

        return planet == null 
            ? SetErrorResponse(RequestNoResultMessage) 
            : (planet.Order, planet.EquatorLength, null);
    }
    
    private (int?, int?, string?) SetErrorResponse(string errorMessage)
    {
        return (null, null, errorMessage);
    }

    private bool TooFrequentRequest()
    {
        return _requestCounter % 3 == 0;
    }
    
    private Planet? GetPlanet(string planetName)
    {
        return PlanetList.FirstOrDefault(p =>
            string.Equals(p.Name, planetName, StringComparison.CurrentCultureIgnoreCase));
    }
}