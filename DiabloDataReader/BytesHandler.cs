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
    public ReadOnlySpan<byte> HeaderGameLink => this[HeaderGameLinkStart, HeaderGameLinkEnd];
    public ReadOnlySpan<byte> HeaderFileType => this[HeaderFileTypeStart, HeaderFileTypeEnd];
    public ReadOnlySpan<byte> HeaderFileTypePadding => this[HeaderFileTypePaddingStart, HeaderFileTypePaddingEnd];
    public ReadOnlySpan<byte> HeaderUnknownFirst => this[HeaderUnknownFirstStart, HeaderUnknownFirstEnd];
    public ReadOnlySpan<byte> HeaderHashId => this[HeaderHashIdStart, HeaderHashIdEnd];
    public ReadOnlySpan<byte> HeaderHashIdPadding => this[HeaderHashIdPaddingStart, HeaderHashIdPaddingEnd];
    public ReadOnlySpan<byte> HeaderUnknownSecond => this[HeaderUnknownSecondStart, HeaderUnknownSecondEnd];
    public ReadOnlySpan<byte> HeaderInfoLength => this[HeaderInfoLengthStart, HeaderInfoLengthEnd];
    public ReadOnlySpan<byte> HeaderInfoLengthPadding => this[HeaderInfoLengthPaddingStart, HeaderInfoLengthPaddingEnd];
    #endregion

    #region Block
    public ReadOnlySpan<byte> BlockDelimiterFirst => this[_offsetBlock + BlockDelimiterFirstStart, _offsetBlock + BlockDelimiterFirstEnd];
    public ReadOnlySpan<byte> BlockKeyOffset => this[_offsetBlock + BlockKeyOffsetStart, _offsetBlock + BlockKeyOffsetEnd];
    public ReadOnlySpan<byte> BlockKeyLength => this[_offsetBlock + BlockKeyLengthStart, _offsetBlock + BlockKeyLengthEnd];
    public ReadOnlySpan<byte> BlockDelimiterSecond => this[_offsetBlock + BlockDelimiterSecondStart, _offsetBlock + BlockDelimiterSecondEnd];
    public ReadOnlySpan<byte> BlockValueOffset => this[_offsetBlock + BlockValueOffsetStart, _offsetBlock + BlockValueOffsetEnd];
    public ReadOnlySpan<byte> BlockValueLength => this[_offsetBlock + BlockValueLengthStart, _offsetBlock + BlockValueLengthEnd];
    public ReadOnlySpan<byte> BlockDelimiterLast => this[_offsetBlock + BlockDelimiterLastStart, _offsetBlock + BlockDelimiterLastEnd];
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