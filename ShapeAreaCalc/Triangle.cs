using System.Net.Http.Headers;
using ShapeAreaCalc.@base;

namespace ShapeAreaCalc;

public class Triangle : Shape
{
    private readonly double[] _triangleSides;

    public Triangle(double a, double b, double c) : base(() =>
    {
        var p = (a + b + c) / 2;
        return double.Sqrt(p * (p - a) * (p - b) * (p - c));
    })
    {
        if (a <= 0 || b <= 0 || c <= 0 ||
            a is double.NaN || b is double.NaN || c is double.NaN ||
            double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c))
            throw new ArgumentOutOfRangeException();

        if ((a + b) < c || (b + c) < a || (c + a) < b)
            throw new ArgumentException("Некорректный размер сторон");
        
        _triangleSides = new []{a,b,c};
    }

    public bool IsRight()
    {
        const double possibleError = 1e-4;
        
        Array.Sort(_triangleSides);
        
        var a = _triangleSides.ElementAt(0);
        var b = _triangleSides.ElementAt(1);
        var c = _triangleSides.ElementAt(2);
        
        return (double.Abs(a * a + b * b - c * c) <= possibleError);
    }
}