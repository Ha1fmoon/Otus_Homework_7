namespace Otus_Homework_7_3;

public class Planet
{
    public string Name { get; set; }
    public int Order { get; set; }
    public int EquatorLength { get; set; }
    public Planet? PreviousPlanet { get; set; }

    public Planet(string name, int order, int equatorLength, Planet? previousPlanet = null)
    {
        Name = name;
        Order = order;
        EquatorLength = equatorLength;
        PreviousPlanet = previousPlanet;
    }
}