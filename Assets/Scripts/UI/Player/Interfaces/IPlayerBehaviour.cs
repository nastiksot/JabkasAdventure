using System;
using UnityEngine;

namespace UI.Player.Interfaces
{
    public interface IPlayerBehaviour
    {
        public Transform PlayerTransform { get; }
        public event Action OnPlayerDeath;
        public void PlayerDeath();
        public void InitializeStomper();
    }
}