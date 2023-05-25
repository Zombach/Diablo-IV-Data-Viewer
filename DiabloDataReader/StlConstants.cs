namespace DiabloDataReader;

public static class StlConstants
{
    public const int HeaderSize = 48;
    public const int PairSize = 40;
    public const int Offset = 16;

    #region Header
    public const int HeaderGameLinkStart = 0;
    public const int HeaderGameLinkEnd = 4;
    public const int HeaderFileTypeStart = 4;
    public const int HeaderFileTypeEnd = 8;
    public const int HeaderFileTypePaddingStart = 8;
    public const int HeaderFileTypePaddingEnd = 12;
    public const int HeaderUnknownFirstStart = 12;
    public const int HeaderUnknownFirstEnd = 16;
    public const int HeaderHashIdStart = 16;
    public const int HeaderHashIdEnd = 20;
    public const int HeaderHashIdPaddingStart = 20;
    public const int HeaderHashIdPaddingEnd = 32;
    public const int HeaderUnknownSecondStart = 32;
    public const int HeaderUnknownSecondEnd = 36;
    public const int HeaderInfoLengthStart = 36;
    public const int HeaderInfoLengthEnd = 40;
    public const int HeaderInfoLengthPaddingStart = 40;
    public const int HeaderInfoLengthPaddingEnd = 48;
    #endregion

    #region Block
    public const int BlockDelimiterFirstStart = 0;
    public const int BlockDelimiterFirstEnd = 8;
    public const int BlockKeyOffsetStart = 8;
    public const int BlockKeyOffsetEnd = 12;
    public const int BlockKeyLengthStart = 12;
    public const int BlockKeyLengthEnd = 16;
    public const int BlockDelimiterSecondStart = 16;
    public const int BlockDelimiterSecondEnd = 24;
    public const int BlockValueOffsetStart = 24;
    public const int BlockValueOffsetEnd = 28;
    public const int BlockValueLengthStart = 28;
    public const int BlockValueLengthEnd = 32;
    public const int BlockDelimiterLastStart = 32;
    public const int BlockDelimiterLastEnd = 40;
    #endregion
}