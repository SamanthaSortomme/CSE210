using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square(12.5, "blue"));
        shapes.Add(new Rectangle(17.442, 11.81, "yellow"));
        shapes.Add(new Circle(54, "purple"));

        foreach (Shape shape in shapes)
        {
            Console.Write($"Color: {shape.GetColor()},  Area: {shape.GetArea()}\n");
        }
    }
}