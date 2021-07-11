using System;
using services.Constants;
using UnityEngine;

namespace UI.Player
{
    public class SheetCollision : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;

        private void Start()
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == Layers.GROUND_LAYER )
            {
                rigidbody2D.bodyType = RigidbodyType2D.Static;
            }
        }
        
    }
}
