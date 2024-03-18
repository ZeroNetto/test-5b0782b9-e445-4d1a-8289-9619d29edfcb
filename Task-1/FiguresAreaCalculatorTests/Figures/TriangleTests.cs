using FiguresAreaCalculator.Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresAreaCalculatorTests.Figures;

[TestFixture]
public class TriangleTests
{
    [TestCase(8, 9, 6, 2, 23.53)]
    [TestCase(3, 4, 5, 1, 6.0)]
    [TestCase(1, 1, 1, 1, 0.4)]
    public void Calculate_ReturnsCalculatedValue(double aSide, double bSide, double cSide, int areaPrecision,
        double expectedValue)
    {
        var triangle = new Triangle(aSide, bSide, cSide);

        triangle.CalculateArea(areaPrecision).Should().Be(expectedValue);
    }

    [TestCase(3, 4, 5, true)]
    [TestCase(1, 1, 1, false)]
    public void IsRectangular_ReturnsAnswer(double aSide, double bSide, double cSide, bool expectedAnswer)
    {
        var triangle = new Triangle(aSide, bSide, cSide);

        triangle.IsRectangular.Should().Be(expectedAnswer);
    }
}