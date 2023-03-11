using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 2.5);

        Rectangle rectangle = new Rectangle("Blue", 2.5, 3);

        Circle circle = new Circle("Yellow", 1);

        List<Shape> listOfShapes = new List<Shape>();
        listOfShapes.Add(square);
        listOfShapes.Add(rectangle);
        listOfShapes.Add(circle);

        foreach(Shape shape in listOfShapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}