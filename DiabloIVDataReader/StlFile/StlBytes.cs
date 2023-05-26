using DiabloDataReader;
using static DiabloIVDataReader.StlFiles.StlConstants;

namespace DiabloIVDataReader.StlFiles;

public class StlBytes : BytesHandler
{
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
    public ReadOnlySpan<byte> BlockDelimiterFirst => this[OffsetBlock + BlockDelimiterFirstStart, OffsetBlock + BlockDelimiterFirstEnd];
    public ReadOnlySpan<byte> BlockKeyOffset => this[OffsetBlock + BlockKeyOffsetStart, OffsetBlock + BlockKeyOffsetEnd];
    public ReadOnlySpan<byte> BlockKeyLength => this[OffsetBlock + BlockKeyLengthStart, OffsetBlock + BlockKeyLengthEnd];
    public ReadOnlySpan<byte> BlockDelimiterSecond => this[OffsetBlock + BlockDelimiterSecondStart, OffsetBlock + BlockDelimiterSecondEnd];
    public ReadOnlySpan<byte> BlockValueOffset => this[OffsetBlock + BlockValueOffsetStart, OffsetBlock + BlockValueOffsetEnd];
    public ReadOnlySpan<byte> BlockValueLength => this[OffsetBlock + BlockValueLengthStart, OffsetBlock + BlockValueLengthEnd];
    public ReadOnlySpan<byte> BlockDelimiterLast => this[OffsetBlock + BlockDelimiterLastStart, OffsetBlock + BlockDelimiterLastEnd];
    #endregion

    public uint CountBlocks => ToUint(HeaderInfoLength) / PairSize;

    public StlBytes(IEnumerable<byte> bytes) : base(bytes, HeaderSize)
    {
    }
}