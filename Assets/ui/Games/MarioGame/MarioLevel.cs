using System;
using DI;
using UI.Base;
using UI.Camera;
using UI.Games.MarioGame.Switcher;
using UnityEngine;

namespace UI.Games.MarioGame
{
    public class MarioLevel : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private SwitchController switchController;
    }
}