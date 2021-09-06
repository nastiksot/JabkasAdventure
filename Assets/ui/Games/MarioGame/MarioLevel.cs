using System;
using DI;
using UI.Base;
using UI.Camera;
using UI.Games.MarioGame.Switcher;
using UnityEngine;

namespace UI.Games.MarioGame
{
    public class MarioLevel : BaseMono
    {
        [SerializeField] private Transform particleHolder;
        [SerializeField] private Transform bonusSheetHolder;

        public Transform ParticleHolder => particleHolder;
        public Transform BonusSheetHolder => bonusSheetHolder;
    }
}