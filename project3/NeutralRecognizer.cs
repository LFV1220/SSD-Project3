using project3;

public class NeutralRecognizer : PatternRecognizer
{
    // A threshold to define how close open and close should be
    private readonly decimal threshold = 0.01m;

    public NeutralRecognizer() : base(1, "Neutral") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for (int i = 0; i < candlesticks.Count; i++)
        {
            if (IsNeutral(candlesticks[i]))
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i,
                    endIndex = i,
                    patternName = "Neutral"
                });
            }
        }

        return matches;
    }

    private bool IsNeutral(smartCandlestick candlestick)
    {
        var bodySize = Math.Abs(candlestick.close - candlestick.open);
        return bodySize <= (threshold * Math.Abs(candlestick.high - candlestick.low));
    }
}