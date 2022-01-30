using System;

namespace Services.Interfaces
{
    public interface IInputService
    {
        public event Action OnJump;
        public event Action OnMoveStopped; 
        public event Action<float> OnMoveStarted;
    }
}