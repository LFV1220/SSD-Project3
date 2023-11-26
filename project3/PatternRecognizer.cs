using project3;

public abstract class PatternRecognizer
{
    public int patternSize;
    public string patternName;

    public PatternRecognizer(int size, string name)
    {
        patternSize = size;
        patternName = name;
    }

    // This method should be overridden in derived classes to identify specific patterns.
    // It should return a collection of identified patterns with their positions or any other relevant data.
    public abstract IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks);
}

// You might want to use a simple class to represent a pattern match, including the position where it was found.
public class PatternMatch
{
    // You can include more properties here if needed, like the pattern name, etc.
    public int startIndex { get; set; } // The index of the candlestick where the pattern starts
    public int endIndex { get; set; } // The index of the candlestick where the pattern ends (for multi-candlestick patterns)
    public string patternName { get; set; } // Name of the pattern
}