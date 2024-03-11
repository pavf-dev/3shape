using System.Collections;

namespace WordCounter3Shape;

public class ByteSequenceReader : IEnumerable<ReadOnlyMemory<byte>>, IEnumerator<ReadOnlyMemory<byte>>
{
    private const int TextChunkSize = 128;
    private readonly byte[] _bytes;
    
    private int _position;
    
    public ByteSequenceReader(byte[] bytes)
    {
        _bytes = bytes;
        Current = ReadOnlyMemory<byte>.Empty;
    }
    
    public IEnumerator<ReadOnlyMemory<byte>> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool MoveNext()
    {
        var nextChunk = GetNextChunk();

        if (nextChunk.Length == 0)
        {
            return false;
        }

        Current = nextChunk;

        return true;
    }

    public void Reset()
    {
        _position = 0;
    }

    public ReadOnlyMemory<byte> Current { get; private set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }
    
    private ReadOnlyMemory<byte> GetNextChunk()
    {
        var chunkSize = Math.Min(TextChunkSize, _bytes.Length - _position);
        
        if (chunkSize == 0) return ReadOnlyMemory<byte>.Empty;
        
        var endPosition = _position + chunkSize;

        while (endPosition < _bytes.Length - 1 && _bytes[endPosition] != 0x20)
        {
            endPosition++;
        }
        
        var nextChunk = _bytes.AsMemory(_position, endPosition - _position);
        _position = endPosition;
        
        return nextChunk;
    }
}