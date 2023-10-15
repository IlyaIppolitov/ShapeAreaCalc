namespace ShapeAreaCalc.@base;

public abstract class Shape
{
    public double Area { get; }
    protected Shape(Func<double> areaCalculator)
    {
        this.Area = areaCalculator();
        if (double.IsInfinity(this.Area))
            throw new ArgumentOutOfRangeException(nameof(Area),"Площадь получилась слищком большой и расчитана некорректно!");
    }
}