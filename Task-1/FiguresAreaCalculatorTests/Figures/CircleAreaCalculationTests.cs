using FiguresAreaCalculator.Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresAreaCalculatorTests.Figures;

[TestFixture]
public class CircleAreaCalculationTests
{
    [TestCase(8, 2, 201.06)]
    [TestCase(3, 1, 28.3)]
    public void Calculate_ReturnsCalculatedValue(double radius, int areaPrecision, double expectedValue)
    {
        var triangle = new Circle(radius, areaPrecision);

        triangle.CalculateArea().Should().Be(expectedValue);
    }
}