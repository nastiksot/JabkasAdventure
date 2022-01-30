using System;
using UnityEngine;

namespace UI.Player.Interfaces
{
    public interface IPlayerBehaviour
    {
        public event Action<Vector3> OnPlayerMove;
        public Vector3 GetPlayerPosition();
    }
}