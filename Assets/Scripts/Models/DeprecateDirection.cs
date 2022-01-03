using System;

namespace Models
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