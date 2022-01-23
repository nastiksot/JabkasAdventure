using System;

namespace Models.Enum
{
    [Flags]
    public enum DeprecateDirection
    {
        None,
        Left,
        Right,
        One = Right | Left
    }
}