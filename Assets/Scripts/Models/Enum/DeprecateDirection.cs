using System;

namespace Models.Enum
{
    [Flags]
    public enum DeprecateDirection
    {
        None = 0,
        Left = 1,
        Right = 2,
        One = Right | Left
    }
}