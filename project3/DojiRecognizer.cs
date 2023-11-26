using project3;

public class DojiRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public DojiRecognizer() : base(1, "Doji") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Logic to identify Doji patterns...
        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(IsDoji(candlesticks[i]))
            {
                matches.Add(new PatternMatch
                {
                    // Doji is a single-candlestick pattern, so start and end are the same
                    endIndex = i, 
                    startIndex = i,
                    patternName = "Doji"
                });
            }
        }

        return matches;
    }

    private bool IsDoji(smartCandlestick candlestick)
    {
        // You will implement the logic here to determine if the candlestick is a Doji
        // A Doji is typically characterized by a very small body compared to its shadows
        var body = Math.Abs(candlestick.close - candlestick.open);
        var range = candlestick.high - candlestick.low;

        // This is just an example threshold, you will define what constitutes a "small body"
        return body <= (range * 0.1m);
    }
}