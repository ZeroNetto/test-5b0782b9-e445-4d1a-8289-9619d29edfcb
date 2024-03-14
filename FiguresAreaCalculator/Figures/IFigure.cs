namespace FiguresAreaCalculator.Figures;

public interface IFigure
{
    public int AreaPrecision { get; }
    public double CalculateArea();
}