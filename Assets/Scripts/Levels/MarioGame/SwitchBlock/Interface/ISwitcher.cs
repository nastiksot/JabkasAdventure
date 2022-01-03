using System;

namespace Levels.MarioGame.SwitchBlock.Interface
{
    public interface ISwitcher
    {
        public void FlipSwitch(); 
        public event Action<bool> OnBlockSwitched;
    }
}