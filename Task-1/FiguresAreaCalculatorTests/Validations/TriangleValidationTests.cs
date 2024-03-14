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

    [TestCaseSource(nameof(NegativeCases))]
    public void CreatingObject(double aSide, double bSide, double cSide, int areaPrecision, string expectedMessage)
    {
        var action = () => new Triangle(aSide, bSide, cSide, areaPrecision);

        action.Should().Throw<ArgumentException>().WithMessage(expectedMessage);
    }

    public static IEnumerable<TestCaseData> NegativeCases()
    {
        yield return new TestCaseData(1, 2, 3, -1, "Original number -1 should be greater than zero").SetName(
            $"{nameof(NegativeCases)}_ForNotPositive_ASide");
        yield return new TestCaseData(0, 2, 3, 2, "Original number 0 should be greater than zero").SetName(
            $"{nameof(NegativeCases)}_ForNotPositive_ASide");
        yield return new TestCaseData(2, 0, 3, 2, "Original number 0 should be greater than zero").SetName(
            $"{nameof(NegativeCases)}_ForNotPositive_BSide");
        yield return new TestCaseData(2, 3, 0, 2, "Original number 0 should be greater than zero").SetName(
            $"{nameof(NegativeCases)}_ForNotPositive_CSide");

        yield return
            new TestCaseData(8, 2, 3, 2, "Original number 8 should be less or equal to other number 5").SetName(
                $"{nameof(NegativeCases)}_ForTooBig_ASide");
        yield return
            new TestCaseData(2, 8, 3, 2, "Original number 8 should be less or equal to other number 5").SetName(
                $"{nameof(NegativeCases)}_ForTooBig_BSide");
        yield return
            new TestCaseData(2, 3, 8, 2, "Original number 8 should be less or equal to other number 5").SetName(
                $"{nameof(NegativeCases)}_ForTooBig_CSide");
    }
}