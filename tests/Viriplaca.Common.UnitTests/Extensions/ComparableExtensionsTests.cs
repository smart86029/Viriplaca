using Viriplaca.Common.Extensions;

namespace Viriplaca.Common.UnitTests.Extensions;

[TestClass]
public class ComparableExtensionsTests
{
    [DataTestMethod]
    [DataRow(0, 0, 100)]
    [DataRow(1, 0, 100)]
    [DataRow(99, 0, 100)]
    [DataRow(100, 0, 100)]
    public void IsBetween_IntValue_True(int value, int infimum, int supremum)
    {
        var result = value.IsBetween(infimum, supremum);

        result.Should().BeTrue();
    }

    [DataTestMethod]
    [DataRow(-1, 0, 100)]
    [DataRow(101, 0, 100)]
    public void IsBetween_IntValue_False(int value, int infimum, int supremum)
    {
        var result = value.IsBetween(infimum, supremum);

        result.Should().BeFalse();
    }
}
