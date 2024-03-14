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

    [TestCase(2, 0, "Original number 0 should be greater than zero")]
    [TestCase(0, 2, "Original number 0 should be greater than zero")]
    public void CreatingObject_Invalid_ThrowsArgumentException(double radius, int areaPrecision, string expectedMessage)
    {
        var action = () => new Circle(radius, areaPrecision);

        action.Should().Throw<ArgumentException>().WithMessage(expectedMessage);
    }
}