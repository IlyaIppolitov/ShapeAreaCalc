namespace ShapeAreaCalc;

public class Circle : Shape
{
    public Circle(double radius) : base(() => Double.Pi * radius * radius)
    {
        if (radius < 0)
            throw new ArgumentException("Не бывает окружностей с отрицательным радиусом!");
    }
}