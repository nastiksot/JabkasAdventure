﻿using UI.Player;
using UnityEngine;

namespace UI.Games.IntroGame
{
    public class IntroLevel : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private MessagePanel messagePanel;
        [SerializeField] private NewsStand newsStand;
        [SerializeField] private TeleportCollision teleportCollision;
    }
}