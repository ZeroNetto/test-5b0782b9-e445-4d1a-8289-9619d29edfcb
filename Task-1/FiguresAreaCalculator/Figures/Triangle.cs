using FiguresAreaCalculator.Validations;

namespace FiguresAreaCalculator.Figures;

public struct Triangle : IFigure
{
    public readonly double ASide;
    public readonly double BSide;
    public readonly double CSide;
    public int AreaPrecision { get; }
    private bool? isRectangular = null;

    public bool IsRectangular
    {
        get
        {
            if (isRectangular.HasValue) return isRectangular.Value;

            var sides = new[] {ASide, BSide, CSide}.OrderDescending().ToArray();
            isRectangular = (sides[0] * sides[0]).CompareTo(sides[1] * sides[1] + sides[2] * sides[2]) == 0;

            return isRectangular.Value;
        }
    }

    public Triangle(double aSide, double bSide, double cSide, int areaPrecision = 2)
    {
        AreaPrecision = areaPrecision.IsGreaterThanZero();
        ASide = aSide.IsGreaterThanZero();
        BSide = bSide.IsGreaterThanZero();
        CSide = cSide.IsGreaterThanZero();

        IsValid();
    }

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