using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLevelImpl : BaseMono,IntroLevel
{
    [SerializeField] private GameObject newsStandObject;
    [SerializeField] private GameObject gameLevelObject;
    [SerializeField] private GameObject messagePanelObject;
    private NewsStand newsStand;
    private MessagePanel messagePanel;
    void Start()
    {
        init();
    }

    public void init()
    {
        newsStand = newsStandObject.GetComponent<NewsStandImpl>();
        messagePanel = messagePanelObject.GetComponent<MessagePanelImpl>();
        newsStand.onStandCollited(() =>
        {
            messagePanel.OpenPanel();
        });
    }
    
}
