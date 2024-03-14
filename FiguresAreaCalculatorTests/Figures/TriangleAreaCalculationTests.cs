﻿using FiguresAreaCalculator.Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresAreaCalculatorTests.Figures;

[TestFixture]
public class TriangleAreaCalculationTests
{
    [TestCase(8, 9, 6, 2, 23.53)]
    [TestCase(3, 4, 5, 1, 6.0)]
    [TestCase(1, 1, 1, 1, 0.4)]
    public void Calculate_ReturnsCalculatedValue(double aSide, double bSide, double cSide, int areaPrecision,
        double expectedValue)
    {
        var triangle = new Triangle(aSide, bSide, cSide, areaPrecision);

        triangle.CalculateArea().Should().Be(expectedValue);
    }
}