using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsStandImpl : BaseMono, NewsStand
{
    [SerializeField] private GameObject bubbleMessage;
    private Action newsStandCollited;

    public void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            newsStandCollited.Invoke();
        });
    }
    

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerBehaviourImpl>())
        {
            dlog("collited stand news"); 
            GetComponent<AudioSource>().Play();
            bubbleMessage.SetActive(true);
            StartCoroutine(HideBubble());
        }
    }

    public void onStandCollited(Action newsStandCollited)
    {
        this.newsStandCollited = newsStandCollited;
    }

    public IEnumerator HideBubble()
    {
        yield return new WaitForSeconds(3);
        bubbleMessage.SetActive(false);
    }
}