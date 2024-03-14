using FiguresAreaCalculator.Validations;

namespace FiguresAreaCalculator.Figures;

public readonly struct Triangle : IFigure
{
    public readonly double ASide;
    public readonly double BSide;
    public readonly double CSide;

    public Triangle(double aSide, double bSide, double cSide, int areaPrecision = 2)
    {
        AreaPrecision = areaPrecision.IsGreaterThanZero();
        ASide = aSide.IsGreaterThanZero();
        BSide = bSide.IsGreaterThanZero();
        CSide = cSide.IsGreaterThanZero();

        IsValid();
    }

    public int AreaPrecision { get; }

    public double CalculateArea()
    {
        var semiPerimeter = (ASide + BSide + CSide) / 2;

        return Math.Round(
            Math.Sqrt(semiPerimeter * (semiPerimeter - ASide) * (semiPerimeter - BSide) * (semiPerimeter - CSide)),
            AreaPrecision);
    }

    private void IsValid()
    {
        ASide.IsLessOrEqualThan(BSide + CSide);
        BSide.IsLessOrEqualThan(ASide + CSide);
        CSide.IsLessOrEqualThan(ASide + BSide);
    }
}