namespace TheMartian.Console.Models;

public class Position
{
    public int CoordinateX { get; set; }
    public int CoordinateY { get; set; }
    public Headings Heading { get; set; }

    public override string ToString()
    {
        return $"{CoordinateX} {CoordinateY} {Heading}";
    }
}
