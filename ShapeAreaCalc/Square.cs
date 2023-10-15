using ShapeAreaCalc.@base;

namespace ShapeAreaCalc;

public class Square : Shape
{
    public Square(double side) : base(() => side * side)
    {
        if (side <= 0)
            throw new ArgumentOutOfRangeException( nameof(side),"Сторона квадрата должна быть больше нуля!");
        if (side is Double.NaN || double.IsInfinity(side))
            throw new ArgumentOutOfRangeException(nameof(side),"Сторона квадрата имеет некорректное значение!");
    }
}