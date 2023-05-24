using System.Text;

namespace DiabloDataReader;

public class Stl
{
    private readonly BytesHandler _bytesHandler;
    public List<KeyValuePair<string, string>> Blocks { get; private set; }

    public Stl(BytesHandler bytes)
    {
        _bytesHandler = bytes;
        Blocks = new();
    }

    public void GetInfo()
    {
        for (int i = 0; i < _bytesHandler.CountBlocks; i++)
        {
            AddBlockInfo();
            _bytesHandler.NextBlock();
        }
    }

    private void AddBlockInfo()
    {
        string key = GetLine(_bytesHandler.BlockKeyOffset, _bytesHandler.BlockKeyLength);
        string value = GetLine(_bytesHandler.BlockValueOffset, _bytesHandler.BlockValueLength);
        Blocks.Add(new KeyValuePair<string, string>(key, value));
    }

    private string GetLine(ReadOnlySpan<byte> offset, ReadOnlySpan<byte> length)
    {
        int offSet = _bytesHandler.ToInt(offset) + StlConstants.Offset;
        int len = _bytesHandler.ToInt(length);
        ReadOnlySpan<byte> bytes = _bytesHandler[offSet, offSet + len];
        string line = Encoding.UTF8.GetString(bytes);
        return line.Replace("\u0000", string.Empty);
    }
}