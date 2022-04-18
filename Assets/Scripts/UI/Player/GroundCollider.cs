using System;
using Models.ConstantValues;
using UnityEngine;

namespace UI.Player
{
    public class GroundCollider : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation playerAnimation;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var collidedGameObject = other.gameObject;
            if (collidedGameObject.layer != LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME)) return;
            playerAnimation.SetIdleAnimation();
        }

    }
}