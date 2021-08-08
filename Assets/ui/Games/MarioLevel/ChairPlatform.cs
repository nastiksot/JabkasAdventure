using Services.Constants;
using UI.Base;
using UI.Player;
using UnityEngine;

namespace UI.Games.MarioLevel
{
    public class ChairPlatform : BaseMono
    {
        [SerializeField] private int jumpPower = 400;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;

            var rb = col.collider.GetComponent<Rigidbody2D>();
            if (rb == null) return;
            var velocity = rb.velocity;
            velocity.y = (jumpPower) * 0.02f;
            rb.velocity = velocity;
        }
    }
}