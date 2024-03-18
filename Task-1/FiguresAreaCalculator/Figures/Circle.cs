using FiguresAreaCalculator.Validations;

namespace FiguresAreaCalculator.Figures;

public struct Circle : IFigure
{
    public readonly double Radius;

    public Circle(double radius)
    {
        Radius = radius.IsGreaterThanZero();
    }

    public double CalculateArea(int areaPrecision = 2)
    {
        areaPrecision.IsGreaterOrEqualToZero();

        return Math.Round(Math.PI * Radius * Radius, areaPrecision);
    }
}