namespace WordCounter3Shape;

public interface IWordParser
{
    IEnumerable<string> ParseFrom(string text);
}

public class DefaultWordParser : IWordParser
{
    private readonly char[] _wordSeparators = new[] { ' ', '.', ',', '!', '?', '(', ')', ':', ';', '\n', '\t', '\r' };
    
    public IEnumerable<string> ParseFrom(string text)
    {
        var words = text.Split(_wordSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        
        return words;
    }
}