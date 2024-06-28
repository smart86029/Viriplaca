namespace Deopeia.Quote.Domain.Ohlcvs;

public class Ohlcv : AggregateRoot
{
    private Ohlcv() { }

    public Ohlcv(
        string symbol,
        DateTimeOffset recordedAt,
        decimal open,
        decimal close,
        decimal high,
        decimal low,
        decimal volume
    )
    {
        Symbol = symbol;
        RecordedAt = recordedAt;
        Open = open;
        Close = close;
        High = high;
        Low = low;
        Volume = volume;
    }

    public string Symbol { get; private init; } = string.Empty;

    public DateTimeOffset RecordedAt { get; private init; }

    public decimal Open { get; private init; }

    public decimal Close { get; private init; }

    public decimal High { get; private init; }

    public decimal Low { get; private init; }

    public decimal Volume { get; private init; }
}
