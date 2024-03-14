using System.Numerics;

namespace FiguresAreaCalculator.Validations;

public static class ValidationsExtensions
{
    public static T IsLessOrEqualThan<T>(this T originalNumber, T otherNumber) where T : INumber<T>
    {
        if (originalNumber.CompareTo(otherNumber) > 0)
            throw new ArgumentException(
                $"Original number {originalNumber} should be less or equal to other number {otherNumber}");

        return originalNumber;
    }

    public static T IsGreaterThanZero<T>(this T originalNumber) where T : INumber<T>
    {
        if (originalNumber.CompareTo(T.Zero) <= 0)
            throw new ArgumentException($"Original number {originalNumber} should be greater than zero");

        return originalNumber;
    }
}