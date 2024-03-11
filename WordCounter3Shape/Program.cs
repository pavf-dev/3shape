using System.Text;
using WordCounter3Shape;

var byteReader = new ByteSequenceReader(File.ReadAllBytes("test-text.txt"));
var wordCounter = new WordCounter(new DefaultWordParser(), new DefaultWordNormalizer());

foreach (var byteChunk in byteReader)
{
    wordCounter.AddWordCountFrom(Encoding.UTF8.GetString(byteChunk.Span));
}

var result = wordCounter.GetWordCount();

foreach (var (word, count) in result)
{
    Console.WriteLine($"{word} {count}");    
}

Console.ReadKey();