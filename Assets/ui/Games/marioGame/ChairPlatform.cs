using UnityEngine;

public class ChairPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<PlayerBehaviourImpl>())
        {
            Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = (PlayerBehaviourImpl.playerJumpPower) * 0.02f;
                rb.velocity = velocity;
            }
        }
    }
}