using System;

public class shape
{
    private int sides;
    private double sideLength;
    private double x;
    private double y;

    public shape(int sides, double sideLength, double x, double y)
    {
        this.sides = sides;
        this.sideLength = sideLength;
        this.x = x;
        this.y = y;
    }

    public bool OverlapsWith(shape otherPolygon)
    {
        // Calculate the radii of the polygons (distance from center to vertex)
        double radius1 = sideLength / (2 * Math.Sin(Math.PI / sides));
        double radius2 = otherPolygon.sideLength / (2 * Math.Sin(Math.PI / otherPolygon.sides));

        // Calculate the distance between the centers of the polygons
        double distance = Math.Sqrt(Math.Pow(otherPolygon.x - x, 2) + Math.Pow(otherPolygon.y - y, 2));

        // Check if the polygons overlap by comparing the sum of their radii with the distance between their centers
        return distance < (radius1 + radius2);
    }

    public double CalculateArea()
    {
        // Calculate the apothem (distance from the center to the midpoint of a side)
        double apothem = sideLength / (2 * Math.Tan(Math.PI / sides));

        // Calculate the area of the regular polygon: 0.5 * perimeter * apothem
        double perimeter = sides * sideLength;
        double area = 0.5 * perimeter * apothem;

        return area;
    }
    
    public int getSides() {
        return this.sides;
    }

    public bool isSame(shape Shape) {
        return (this.sides == Shape.getSides());
    }
}