using System;

namespace UI.Levels.MarioGame.SwitchBlock.Interface
{
    public interface ISwitcher
    {
        public void FlipSwitch();
        public bool IsOn { get; set; }
        public event Action<bool> OnBlockSwitched;
    }
}