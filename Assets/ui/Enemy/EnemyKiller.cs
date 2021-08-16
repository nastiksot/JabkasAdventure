using System;
using DI.Services.Constants;
using UnityEngine;

namespace UI.Enemy
{
    public class EnemyKiller : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.PLAYER_TAG))
            {
                Destroy(other.gameObject);
            }
        } 
    }
}