using static DiabloDataReader.StlConstants;

namespace DiabloDataReader;

public class BytesHandler
{
    private readonly byte[] _bytes;
    private int _offsetBlock;

    public ReadOnlySpan<byte> this[int start = -1, int end = -1]
    => (start, end) switch
    {
        ( >= 0, >= 0) => start <= end ? _bytes[start..end] : _bytes[end..start],
        ( >= 0, < 0) => _bytes[start..],
        ( < 0, > 0) => _bytes[..end],
        _ => _bytes
    };

    #region Header
    public ReadOnlySpan<byte> HeaderGameLink => this[0, 4];
    public ReadOnlySpan<byte> HeaderFileType => this[4, 8];
    public ReadOnlySpan<byte> HeaderFileTypePadding => this[8, 12];
    public ReadOnlySpan<byte> HeaderUnknownFirst => this[12, 16];
    public ReadOnlySpan<byte> HeaderHashId => this[16, 20];
    public ReadOnlySpan<byte> HeaderHashIdPadding => this[20, 32];
    public ReadOnlySpan<byte> HeaderUnknownSecond => this[32, 36];
    public ReadOnlySpan<byte> HeaderInfoLength => this[36, 40];
    public ReadOnlySpan<byte> HeaderInfoLengthPadding => this[40, 48];
    #endregion

    #region Block
    public ReadOnlySpan<byte> BlockDelimiterStart => this[_offsetBlock, _offsetBlock + 8];
    public ReadOnlySpan<byte> BlockKeyOffset => this[_offsetBlock + 8, _offsetBlock + 12];
    public ReadOnlySpan<byte> BlockKeyLength => this[_offsetBlock + 12, _offsetBlock + 16];
    public ReadOnlySpan<byte> BlockDelimiterSecond => this[_offsetBlock + 16, _offsetBlock + 24];
    public ReadOnlySpan<byte> BlockValueOffset => this[_offsetBlock + 24, _offsetBlock + 28];
    public ReadOnlySpan<byte> BlockValueLength => this[_offsetBlock + 28, _offsetBlock + 32];
    public ReadOnlySpan<byte> BlockDelimiterLast => this[_offsetBlock + 32, _offsetBlock + 40];
    #endregion

    public int CountBlocks => ToInt(HeaderInfoLength) / PairSize;

    public BytesHandler(IEnumerable<byte> bytes)
    {
        _bytes = bytes.ToArray();
        _offsetBlock = HeaderSize;
    }
    public int ToInt(ReadOnlySpan<byte> bytes) => BitConverter.ToInt32(bytes);
    public void NextBlock() => _offsetBlock += PairSize;
}