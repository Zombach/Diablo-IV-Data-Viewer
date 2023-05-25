using System.Text;

namespace DiabloDataReader;

public class Stl
{
    private readonly BytesStl _bytesStl;
    public List<KeyValuePair<string, string>> Blocks { get; private set; }

    public Stl(BytesStl bytes)
    {
        _bytesStl = bytes;
        Blocks = new();
    }
    
    public void GetInfo()
    {
        for (int i = 0; i < _bytesStl.CountBlocks; i++)
        {
            AddBlockInfo();
            _bytesStl.NextBlock(StlConstants.PairSize);
        }
    }

    private void AddBlockInfo()
    {
        string key = GetLine(_bytesStl.BlockKeyOffset, _bytesStl.BlockKeyLength);
        string value = GetLine(_bytesStl.BlockValueOffset, _bytesStl.BlockValueLength);
        Blocks.Add(new KeyValuePair<string, string>(key, value));
    }

    private string GetLine(ReadOnlySpan<byte> offset, ReadOnlySpan<byte> length)
    {
        uint offSet = _bytesStl.ToUint(offset) + StlConstants.Offset;
        uint len = _bytesStl.ToUint(length);
        ReadOnlySpan<byte> bytes = _bytesStl[offSet, offSet + len];
        string line = Encoding.UTF8.GetString(bytes);
        return line.Replace("\u0000", string.Empty);
    }
}