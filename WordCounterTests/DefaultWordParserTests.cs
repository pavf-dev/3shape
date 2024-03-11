using WordCounter3Shape;

namespace WordCounterTests;

public class DefaultWordParserTests
{
    private readonly DefaultWordParser _wordParser = new DefaultWordParser();
    
    [Test]
    public void Parses_spaces()
    {
        var text = " Hello  World ";
        var words = _wordParser.ParseFrom(text);
        
        Assert.That(words, Is.EqualTo(new[] { "Hello", "World" }));
    }
    
    [Test]
    public void Parses_tab_symbol_right()
    {
        var words = _wordParser.ParseFrom("text with \ttabs");
        
        Assert.That(words, Is.EqualTo(new[] { "text", "with", "tabs"}));
    }
    
    [Test]
    public void Parses_new_line_symbol_right()
    {
        var words = _wordParser.ParseFrom("text with new\n\rlines");
        
        Assert.That(words, Is.EqualTo(new[] { "text", "with", "new", "lines"}));
    }
}