using System.Net;

namespace Otus_Homework_7;

class Program
{
    static void Main(string[] args)
    {
        CreatePlanets();
    }

    static void CreatePlanets()
    {
        var venus = new 
        { 
            Name = "Venus", 
            Order = 2, 
            EquatorLength = 38025, 
            PreviousPlanet = (object)null 
        };
        
        PrintPlanetInfo(venus.Name, venus.Order, venus.EquatorLength);
        PrintIsEqualsToVenus(venus.Name, venus.Equals(venus));
        
        var earth = new
        {
            Name = "Earth", 
            Order = 3, 
            EquatorLength = 40075, 
            PreviousPlanet = venus
        };
        
        PrintPlanetInfo(earth.Name, earth.Order, earth.EquatorLength, earth.PreviousPlanet.Name);
        PrintIsEqualsToVenus(earth.Name, earth.Equals(venus));
        
        var mars = new
        {
            Name = "Mars", 
            Order = 4, 
            EquatorLength = 21344, 
            PreviousPlanet = earth
        };
        
        PrintPlanetInfo(mars.Name, mars.Order, mars.EquatorLength, mars.PreviousPlanet.Name);
        PrintIsEqualsToVenus(mars.Name, mars.Equals(venus));
        
        var venus2 = new
        {
            Name = "Venus", 
            Order = 2, 
            EquatorLength = 38025, 
            PreviousPlanet = mars
        };
        
        PrintPlanetInfo(venus2.Name, venus2.Order, venus2.EquatorLength, venus2.PreviousPlanet.Name);
        PrintIsEqualsToVenus(venus2.Name, venus2.Equals(venus));
    }

    static void PrintPlanetInfo(string name, int order, int equatorLength, string previousPlanetName = "No previous planet")
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Order: {order}");
        Console.WriteLine($"Equator length: {equatorLength}");
        Console.WriteLine($"Previous planet: {previousPlanetName}");
        Console.WriteLine();
    }

    static void PrintIsEqualsToVenus(string name, bool isEquals)
    {
        var prefix = isEquals ? "" : "not";
        Console.WriteLine($"{name} is {prefix} equals to Venus.");
        Console.WriteLine();
    }
}