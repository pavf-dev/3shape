namespace WordCounter3Shape;

public class WordCounter
{
    private readonly Dictionary<string, int> _wordCount = new();
    private readonly IWordParser _wordParser;
    private readonly IWordNormalizer _wordNormalizer;

    public WordCounter(
        IWordParser wordParser,
        IWordNormalizer wordNormalizer)
    {
        _wordParser = wordParser;
        _wordNormalizer = wordNormalizer;
    }
    
    public void AddWordCountFrom(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;
        
        var words = _wordParser.ParseFrom(text);
        var normalizedWords = _wordNormalizer.Normalize(words);

        foreach (var word in normalizedWords)
        {
            if (!_wordCount.TryAdd(word, 1))
            {
                _wordCount[word]++;
            }
        }
    }
    
    public IReadOnlyDictionary<string, int> GetWordCount()
    {
        return _wordCount;
    }
}