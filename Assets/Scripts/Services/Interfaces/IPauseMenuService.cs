using System;

namespace Services.Interfaces
{
    public interface IPauseMenuService
    {
        public event Action OnContinueButtonPressed;
        public event Action OnPauseButtonPressed;
        public event Action OnExitButtonPressed;
        public void SetPauseButtonState(bool state);
    }
}