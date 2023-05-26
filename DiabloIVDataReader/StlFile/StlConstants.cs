namespace DiabloIVDataReader.StlFiles;

public static class StlConstants
{
    /// <summary>
    /// 48
    /// </summary>
    public const uint HeaderSize = 0x30;
    /// <summary>
    /// 40
    /// </summary>
    public const uint PairSize = 0x28;
    /// <summary>
    /// 16
    /// </summary>
    public const uint Offset = 0x10;

    #region Header
    /// <summary>
    /// 0
    /// </summary>
    public const uint HeaderGameLinkStart = 0x0;
    /// <summary>
    /// 4
    /// </summary>
    public const uint HeaderGameLinkEnd = 0x4;
    /// <summary>
    /// 4
    /// </summary>
    public const uint HeaderFileTypeStart = 0x4;
    /// <summary>
    /// 8
    /// </summary>
    public const uint HeaderFileTypeEnd = 0x8;
    /// <summary>
    /// 8
    /// </summary>
    public const uint HeaderFileTypePaddingStart = 0x8;
    /// <summary>
    /// 12
    /// </summary>
    public const uint HeaderFileTypePaddingEnd = 0xc;
    /// <summary>
    /// 12
    /// </summary>
    public const uint HeaderUnknownFirstStart = 0xc;
    /// <summary>
    /// 16
    /// </summary>
    public const uint HeaderUnknownFirstEnd = 0x10;
    /// <summary>
    /// 16
    /// </summary>
    public const uint HeaderHashIdStart = 0x10;
    /// <summary>
    /// 20
    /// </summary>
    public const uint HeaderHashIdEnd = 0x14;
    /// <summary>
    /// 20
    /// </summary>
    public const uint HeaderHashIdPaddingStart = 0x14;
    /// <summary>
    /// 32
    /// </summary>
    public const uint HeaderHashIdPaddingEnd = 0x20;
    /// <summary>
    /// 32
    /// </summary>
    public const uint HeaderUnknownSecondStart = 0x20;
    /// <summary>
    /// 36
    /// </summary>
    public const uint HeaderUnknownSecondEnd = 0x24;
    /// <summary>
    /// 36
    /// </summary>
    public const uint HeaderInfoLengthStart = 0x24;
    /// <summary>
    /// 40
    /// </summary>
    public const uint HeaderInfoLengthEnd = 0x28;
    /// <summary>
    /// 40
    /// </summary>
    public const uint HeaderInfoLengthPaddingStart = 0x28;
    /// <summary>
    /// 48
    /// </summary>
    public const uint HeaderInfoLengthPaddingEnd = 0x30;
    #endregion

    #region Block
    /// <summary>
    /// 0
    /// </summary>
    public const uint BlockDelimiterFirstStart = 0x0;
    /// <summary>
    /// 8
    /// </summary>
    public const uint BlockDelimiterFirstEnd = 0x8;
    /// <summary>
    /// 8
    /// </summary>
    public const uint BlockKeyOffsetStart = 0x8;
    /// <summary>
    /// 12
    /// </summary>
    public const uint BlockKeyOffsetEnd = 0xc;
    /// <summary>
    /// 12
    /// </summary>
    public const uint BlockKeyLengthStart = 0xc;
    /// <summary>
    /// 16
    /// </summary>
    public const uint BlockKeyLengthEnd = 0x10;
    /// <summary>
    /// 16
    /// </summary>
    public const uint BlockDelimiterSecondStart = 0x10;
    /// <summary>
    /// 24
    /// </summary>
    public const uint BlockDelimiterSecondEnd = 0x18;
    /// <summary>
    /// 24
    /// </summary>
    public const uint BlockValueOffsetStart = 0x18;
    /// <summary>
    /// 28
    /// </summary>
    public const uint BlockValueOffsetEnd = 0x1c;
    /// <summary>
    /// 28
    /// </summary>
    public const uint BlockValueLengthStart = 0x1c;
    /// <summary>
    /// 32
    /// </summary>
    public const uint BlockValueLengthEnd = 0x20;
    /// <summary>
    /// 32
    /// </summary>
    public const uint BlockDelimiterLastStart = 0x20;
    /// <summary>
    /// 40
    /// </summary>
    public const uint BlockDelimiterLastEnd = 0x28;
    #endregion
}