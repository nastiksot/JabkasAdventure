using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaivourImpl : BaseMono
{
    private int enemySpeed = 1;

    //move direction default = right
    private int XMoveDirection = 1;
    private bool isTouched;
    private bool facingRight = false;

    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * enemySpeed;
        if (isTouched)
        {
            FlipSpider();
        }
    }

    void FlipSpider()
    {
        if (XMoveDirection > 0 && isTouched)
        {
            XMoveDirection = -1;
            FlipFace();
        }
        else if (XMoveDirection < 0 && isTouched)
        {
            XMoveDirection = 1;
            FlipFace();
        }

        isTouched = false;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        //If frog collited wiht enemy, frog dies
        if (collision2D.gameObject.GetComponent<PlayerBehaviourImpl>())
        {
            //animation frog dies
           dlog("DIE");
            // MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().openProgressBar();
        }
        else
        {
            isTouched = true;
        }
    }


    void FlipFace()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}