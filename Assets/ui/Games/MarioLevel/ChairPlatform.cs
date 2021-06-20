using UnityEngine;

public class ChairPlatform : BaseMono
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;

        var rb = col.collider.GetComponent<Rigidbody2D>();
        if (rb == null) return;
        var velocity = rb.velocity;
        velocity.y = (PlayerBehaviour.playerJumpPower) * 0.02f;
        rb.velocity = velocity;
    }
}