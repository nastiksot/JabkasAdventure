using Models.ConstantValues;
using UnityEngine;

namespace UI.Levels.MarioGame
{
    public class ChairPlatform : MonoBehaviour
    {
        [SerializeField] private int jumpPower = 400;
        [SerializeField] private AudioSource jumpAudio;
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return; 
            var rb = col.collider.GetComponent<Rigidbody2D>();
            if (rb == null) return;
            jumpAudio.Play();
            rb.AddForce(Vector2.up * jumpPower);
        }
    }
}