using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsStandImpl : BaseMono, NewsStand
{
    [SerializeField] private GameObject bubbleMessage;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button newsStandButton;
    private Action newsStandCollited;

    public void Start()
    {
        newsStandButton.onClick.AddListener(() =>
        {
            newsStandCollited.Invoke();
        });
    }
    

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
        dlog("collited stand news"); 
        audioSource.Play();
        bubbleMessage.SetActive(true);
        StartCoroutine(HideBubble());
    }

    public void OnStandCollited(Action newsStandCollited)
    {
        this.newsStandCollited = newsStandCollited;
    }

    public IEnumerator HideBubble()
    {
        yield return new WaitForSeconds(3);
        bubbleMessage.SetActive(false);
    }
}