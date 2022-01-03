using Models;
using UnityEngine;

namespace Levels.MarioGame
{
    public class ChairPlatform : MonoBehaviour
    {
        [SerializeField] private int jumpPower = 400;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return; 
            var rb = col.collider.GetComponent<Rigidbody2D>();
            if (rb == null) return;
            rb.AddForce(Vector2.up * jumpPower);
        }
    }
}