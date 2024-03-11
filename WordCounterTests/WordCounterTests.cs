using FluentAssertions;
using WordCounter3Shape;

namespace WordCounterTests;

public class WordCounterTests
{
    [Test]
    public void Counts_words_in_general_text()
    {
        var text1 = "This is a test text.\n";
        var text2 = "Here is a question: Is it any good test(text)?";
        
        var wordCounter = new WordCounter(new DefaultWordParser(), new DefaultWordNormalizer());
        wordCounter.AddWordCountFrom(text1);
        wordCounter.AddWordCountFrom(text2);
        var result = wordCounter.GetWordCount();

        result.Should().HaveCount(10);
        result.Should().Contain("this", 1);
        result.Should().Contain("is", 3);
        result.Should().Contain("a", 2);
        result.Should().Contain("test", 2);
        result.Should().Contain("text", 2);
        result.Should().Contain("here", 1);
        result.Should().Contain("question", 1);
        result.Should().Contain("it", 1);
        result.Should().Contain("any", 1);
        result.Should().Contain("good", 1);
    }
}