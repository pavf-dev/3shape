namespace WordCounter3Shape;

public interface IWordNormalizer
{
    public IEnumerable<string> Normalize(IEnumerable<string> words);
}

public class DefaultWordNormalizer : IWordNormalizer
{
    public IEnumerable<string> Normalize(IEnumerable<string> words)
    {
        return words.Select(word => word.ToLowerInvariant());
    }
}