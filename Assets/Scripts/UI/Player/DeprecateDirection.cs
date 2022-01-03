using System;

namespace UI.Player
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