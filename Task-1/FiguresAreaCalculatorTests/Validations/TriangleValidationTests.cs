using FiguresAreaCalculator.Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresAreaCalculatorTests.Validations;

[TestFixture]
public class TriangleValidationTests
{
    [Test]
    public void CreatingObject_Valid_Success()
    {
        var action = () => new Triangle(2, 3, 4);

        action.Should().NotThrow<ArgumentException>();
    }

    [TestCaseSource(nameof(Creating_NegativeCases))]
    public void CreatingObject(double aSide, double bSide, double cSide, string expectedMessage)
    {
        var action = () => new Triangle(aSide, bSide, cSide);

        action.Should().Throw<ArgumentException>().WithMessage(expectedMessage);
    }

    [Test]
    public void CalculateArea_InvalidAreaPrecision_ThrowsArgumentException()
    {
        var action = () => new Triangle(5, 5, 5).CalculateArea(-1);

        action.Should().Throw<ArgumentException>()
            .WithMessage("Original number -1 should be equals or greater than zero");
    }

    public static IEnumerable<TestCaseData> Creating_NegativeCases()
    {
        yield return new TestCaseData(0, 2, 3, "Original number 0 should be greater than zero").SetName(
            $"{nameof(Creating_NegativeCases)}_ForNotPositive_ASide");
        yield return new TestCaseData(2, 0, 3, "Original number 0 should be greater than zero").SetName(
            $"{nameof(Creating_NegativeCases)}_ForNotPositive_BSide");
        yield return new TestCaseData(2, 3, 0, "Original number 0 should be greater than zero").SetName(
            $"{nameof(Creating_NegativeCases)}_ForNotPositive_CSide");

        yield return
            new TestCaseData(8, 2, 3, "Original number 8 should be less or equal to other number 5").SetName(
                $"{nameof(Creating_NegativeCases)}_ForTooBig_ASide");
        yield return
            new TestCaseData(2, 8, 3, "Original number 8 should be less or equal to other number 5").SetName(
                $"{nameof(Creating_NegativeCases)}_ForTooBig_BSide");
        yield return
            new TestCaseData(2, 3, 8, "Original number 8 should be less or equal to other number 5").SetName(
                $"{nameof(Creating_NegativeCases)}_ForTooBig_CSide");
    }
}