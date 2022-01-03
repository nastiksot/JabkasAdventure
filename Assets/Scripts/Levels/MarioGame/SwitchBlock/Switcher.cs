using System;
using Levels.MarioGame.SwitchBlock.Interface;
using UnityEngine;

namespace Levels.MarioGame.SwitchBlock
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