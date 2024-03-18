using FiguresAreaCalculator.Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresAreaCalculatorTests.Validations;

public class CircleValidationTests
{
    [Test]
    public void CreatingObject_Valid_Success()
    {
        var action = () => new Circle(5);

        action.Should().NotThrow<ArgumentException>();
    }

    [Test]
    public void CalculateArea_InvalidAreaPrecision_ThrowsArgumentException()
    {
        var action = () => new Triangle(5, 5, 5).CalculateArea(-1);

        action.Should().Throw<ArgumentException>()
            .WithMessage("Original number -1 should be equals or greater than zero");
    }

    [Test]
    public void CreatingObject_Invalid_ThrowsArgumentException()
    {
        var action = () => new Circle(0);

        action.Should().Throw<ArgumentException>().WithMessage("Original number 0 should be greater than zero");
    }
}