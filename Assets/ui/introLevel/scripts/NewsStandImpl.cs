using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsStandImpl : BaseMono
{
    [SerializeField] private GameObject bubbleMessage;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerBehaviourImpl>())
        {
            dlog("collited stand news");
            bubbleMessage.SetActive(true);
            StartCoroutine(HideBubble());
        }
    }
    IEnumerator HideBubble()
    {
        yield return new WaitForSeconds(3);
        bubbleMessage.SetActive(false);
    }

}