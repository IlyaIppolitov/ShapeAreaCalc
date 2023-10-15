using FluentAssertions;
using ShapeAreaCalc.@base;

namespace ShapeAreaCalc.Test;

public class AreaTests
{

    // Unknow type
    [Fact]
    public void creation_of_unknown_type_of_shape()
    {
        // Arrange
        const int radius = 5;
        const double expectedArea = double.Pi * radius * radius;
        
        const string typeName = "circle";
        Shape? shape = null;
        
        // Act
        switch (typeName.ToLower())
        {
            case "circle": 
                shape = new Circle(radius);
                break;
            case "triangle":
                shape = new Triangle(3, 4, 5);
                break;
        }
        
        // Assert
        Assert.NotNull(shape);
        Assert.Equal(expectedArea, shape.Area);
    }
    
    
    // Circle --------------------------------------------------------------------------------------------------------//
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void circle_area_calculated(double radius)
    {
        // Arrange
        var expectedArea = double.Pi * radius * radius;

        // Act
        var circle = new Circle(radius);

        // Assert
        circle.Area.Should().Be(expectedArea);
        // Assert.Equal(expectedArea, circle.Area);
    }
    
    [Theory]
    [InlineData(-4)]
    [InlineData(double.MaxValue)]
    [InlineData(double.NaN)]
    public void circle_area_not_calculated_bad_radius(double r)
    {
        // Arrange
        // Act
        // Assert
        FluentActions.Invoking(() => { new Circle(r);})
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>();
    }
    
    
    // Triangle-------------------------------------------------------------------------------------------------------//

    [Theory]
    [InlineData(3, 4, 5)]
    public void triangle_area_calculated_and_checked_for_right(double a, double b, double c)
    {
        // Arrange
        var p = (a + b + c) / 2;
        var expectedArea = double.Sqrt(p * (p - a) * (p - b) * (p - c));

        // Act
        var triangle = new Triangle(a, b, c);

        // Assert
        Assert.Equal(expectedArea, triangle.Area);
        Assert.True(triangle.IsRight());
    }

    [Theory]
    [InlineData(3, 4, 10)]
    [InlineData(16, 1, 2)]
    public void triangle_area_not_calculated_with_exception(double a, double b, double c)
    {
        // Arrange

        // Act
        // Assert
        FluentActions.Invoking(() => { new Triangle(a,b,c);})
            .Should()
            .ThrowExactly<ArgumentException>();
    }

    [Theory]
    [InlineData(5, 4, 5)]
    public void triangle_area_calculated_and_checked_for_right_with_false(double a, double b, double c)
    {
        // Arrange
        var p = (a + b + c) / 2;
        var expectedArea = double.Sqrt(p * (p - a) * (p - b) * (p - c));

        // Act
        var triangle = new Triangle(a, b, c);

        // Assert
        Assert.Equal(expectedArea, triangle.Area);
        Assert.False(triangle.IsRight());
    }

    [Theory]
    [InlineData(double.PositiveInfinity, 4, 5)]
    [InlineData(3, double.PositiveInfinity, 5)]
    [InlineData(3, 4, double.PositiveInfinity)]
    public void triangle_not_created_with_infinity_side(double a, double b, double c)
    {
        // Arrange
        // Act
        // Assert
        FluentActions.Invoking(() => { new Triangle(a,b,c);})
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>();
    }
    
    
    // Square---------------------------------------------------------------------------------------------------------//
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void square_area_calculated(double side)
    {
        // Arrange
        var expectedArea = side * side;

        // Act
        var square = new Square(side);

        // Assert
        square.Area.Should().Be(expectedArea);
    }
    
    [Theory]
    [InlineData(double.MaxValue)]
    [InlineData(double.NaN)]
    [InlineData(-5)]
    public void square_area_not_calculated_with_bad_side(double s)
    {
        // Arrange
        // Act
        // Assert
        FluentActions.Invoking(() => { new Square(s);})
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>();
    }
}