using FiguresAreaCalculator.Validations;

namespace FiguresAreaCalculator.Figures;

public readonly struct Circle : IFigure
{
    public readonly double Radius;

    public Circle(double radius, int areaPrecision = 2)
    {
        AreaPrecision = areaPrecision.IsGreaterThanZero();
        Radius = radius.IsGreaterThanZero();
    }

    public int AreaPrecision { get; }

    public double CalculateArea()
    {
        return Math.Round(Math.PI * Radius * Radius, AreaPrecision);
    }
}