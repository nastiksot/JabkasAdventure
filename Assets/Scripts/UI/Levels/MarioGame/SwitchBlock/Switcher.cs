using System;
using UI.Levels.MarioGame.SwitchBlock.Interface;

namespace UI.Levels.MarioGame.SwitchBlock
{
    public class Switcher : ISwitcher 
    {
        private bool isOn = false;
        
        public event Action<bool> OnBlockSwitched;
        public bool IsOn
        {
            get => isOn;
            set => isOn = value;
        } 

        public void FlipSwitch()
        {
            isOn = !isOn;
            OnBlockSwitched?.Invoke(isOn);
        }
    }
}