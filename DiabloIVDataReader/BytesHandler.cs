namespace DiabloDataReader;

public abstract class BytesHandler
{
    private readonly byte[] _bytes;
    protected uint OffsetBlock;

    public ReadOnlySpan<byte> this[uint start, uint end = 0]
    => (start, end) switch
    {
        ( > 0, > 0) => start <= end ? _bytes[(int)start..(int)end] : _bytes[(int)end..(int)start],
        ( > 0, _) => _bytes[(int)start..],
        (_, > 0) => _bytes[..(int)end],
        _ => _bytes
    };

    protected BytesHandler(IEnumerable<byte> bytes, uint offsetBlock)
    {
        _bytes = bytes.ToArray();
        OffsetBlock = offsetBlock;
    }
    
    public uint ToUint(ReadOnlySpan<byte> bytes) => BitConverter.ToUInt32(bytes);
    public string ToString(ReadOnlySpan<byte> bytes) => BitConverter.ToString(bytes.ToArray());

    public List<char> ToChars(ReadOnlySpan<byte> bytes)
    {
        byte[] bs = bytes.ToArray();
        List<char> chars = new();
        for (uint i = 0; i < bs.Length / 2; i++)
        {
            chars.Add(ToChar(bs, i * 2));
        }

        return chars;
    }

    public void NextBlock(uint pairSize) => OffsetBlock += pairSize;

    private char ToChar(ReadOnlySpan<byte> bytes, uint index) => BitConverter.ToChar(bytes.ToArray(), (int)index);
}