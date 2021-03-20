using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroGameManagerImpl : BaseMono
{
    [SerializeField] private GameObject newsStandObject; 
    [SerializeField] private GameObject messagePanelObject;
    private NewsStand newsStand;
    private MessagePanel messagePanel;
    void Start()
    {
        init();
    }

    private void init()
    {
        newsStand = newsStandObject.GetComponent<NewsStandImpl>();
        messagePanel = messagePanelObject.GetComponent<MessagePanelImpl>();
        newsStand.onStandCollited(() =>
        {
            messagePanel.OpenPanel();
        });
    }
    
}
