using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomperScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            rb2d.AddForce(Vector2.up * (PlayerBehaviourImpl.playerJumpPower * 1.5f));
            //die animation of enemy
            //enemyKill.Play();
            Destroy(collision.gameObject.GetComponentInParent<EnemyBehaivourImpl>().gameObject);
        }
    }
}