﻿namespace Hardware.Utils
{
    public enum Speed
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Eleven = 11,
        Twelve = 12,
    }

    public enum Density
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Eleven = 11,
        Twelve = 12,
        Thirteen = 13,
        Fourteen = 14,
        Fifteen = 15,
    }

    public enum Sensor
    {
        Zero = 0,
        One = 1,
    }

    // \\palych\VladimirStandardCorp\TSC BarCode Printer ML340P\SDKs\Pdf\TSC_TSPL_TSPL2_Programming.pdf
    public enum Status
    {
        Zero = 0,       // 00 Normal
        One = 1,        // 01 Head opened
        Two = 2,        // 02 Paper Jam
        Three = 3,      // 03 Paper Jam and head opened
        Four = 4,       // 04 Out of paper
        Five = 5,       // 05 Out of paper and head opened
        Eight = 8,      // 08 Out of ribbon
        Nine = 9,       // 09 Out of ribbon and head opened
        Ten = 10,       // 0A Out of ribbon and paper jam
        Eleven = 11,    // 0B Out of ribbon, paper jam and head opened
        Twelve = 12,    // 0C Out of ribbon and out of paper
        Thirteen = 13,  // 0D Out of ribbon, out of paper and head opened
        Sixteen = 16,   // 10 Pause
        ThirtyTwo = 32, // 20 Printing
        HundredTwentyEight = 128, // 80 Other error
    }

    public enum InitialCrcValue
    {
        Zeros,
        NonZero1 = 0xffff,
        NonZero2 = 0x1D0F,
    }
}