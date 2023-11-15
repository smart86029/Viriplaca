namespace Viriplaca.Common.Extensions;

public static class ComparableExtensions
{
    public static bool IsBetween<TValue>(this TValue value, TValue minInclusive, TValue maxInclusive)
        where TValue : IComparable<TValue>
    {
        return value.CompareTo(minInclusive) >= 0 && value.CompareTo(maxInclusive) <= 0;
    }
}
