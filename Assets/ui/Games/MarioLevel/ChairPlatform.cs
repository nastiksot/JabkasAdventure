using Services.Constants;
using UI.Base;
using UnityEngine;

namespace UI.Games.MarioLevel
{
    public class ChairPlatform : BaseMono
    {
        [SerializeField] private PlayerBehaviour playerBehaviour;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;

            var rb = col.collider.GetComponent<Rigidbody2D>();
            if (rb == null) return;
            var velocity = rb.velocity;
            velocity.y = (playerBehaviour.JumpPower) * 0.02f;
            rb.velocity = velocity;
        }
    }
}