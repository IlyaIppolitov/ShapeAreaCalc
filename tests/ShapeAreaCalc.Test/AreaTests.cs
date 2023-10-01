namespace ShapeAreaCalc.Test;

public class AreaTests
{
    [Fact]
    public void circle_area_calculated()
    {
        // Arrange
        var radius = 5;
        var expectedArea = double.Pi * radius * radius;

        // Act
        var circle = new Circle(radius);

        // Assert
        Assert.Equal(expectedArea, circle.GetArea);
    }
    [Fact]
    public void circle_area_not_calculated_with_exception()
    {
        // Arrange
        var radius = -4;

        // Act
        // Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var circle = new Circle(radius);
        });
    }
    
    [Fact]
    public void triangle_area_calculated_and_checked_for_right()
    {
        // Arrange
        var a = 3;
        var b = 4;
        var c = 5;
        var p = (a + b + c) / 2;
        var expectedArea = double.Sqrt(p * (p - a) * (p - b) * (p - c));

        // Act
        var triangle = new Triangle(a, b, c);

        // Assert
        Assert.Equal(expectedArea, triangle.GetArea);
        Assert.True(triangle.IsRight());
    }
    
    [Fact]
    public void triangle_area_not_calculated_with_exception()
    {
        // Arrange
        var a = 3;
        var b = 4;
        var c = 10;

        // Act
        // Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var triangle = new Triangle(a, b, c);
        });
    }
    
    [Fact]
    public void triangle_area_calculated_and_checked_for_right_with_false()
    {
        // Arrange
        var a = 5;
        var b = 4;
        var c = 5;
        var p = (a + b + c) / 2;
        var expectedArea = double.Sqrt(p * (p - a) * (p - b) * (p - c));

        // Act
        var triangle = new Triangle(a, b, c);

        // Assert
        Assert.Equal(expectedArea, triangle.GetArea);
        Assert.False(triangle.IsRight());
    }

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
        Assert.Equal(expectedArea, shape.GetArea);
    }
}