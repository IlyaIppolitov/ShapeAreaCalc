namespace ShapeAreaCalc;

public abstract class Shape
{
    private readonly double _area;

    protected Shape(Func<double> areaCalculator)
    {
        this._area = areaCalculator();
    }

    public double GetArea => _area;
}