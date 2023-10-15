using ShapeAreaCalc.@base;

namespace ShapeAreaCalc;

public class Circle : Shape
{
    public Circle(double radius) : base(() => Double.Pi * radius * radius)
    {
        if (radius < 0)
            throw new ArgumentOutOfRangeException(nameof(radius),"Радиус должен быть больше нуля!");
        if (radius is Double.NaN || double.IsInfinity(radius))
            throw new ArgumentOutOfRangeException(nameof(radius),"Радиус имеет некорректное значение!");
    }
}