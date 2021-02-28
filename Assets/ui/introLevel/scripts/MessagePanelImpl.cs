using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanelImpl : BaseMono, MessagePanel
{
 
    [SerializeField] GameObject panel;
    private static bool isOpen = false;

    private void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        isOpen = false;
    }

    void OpenPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        isOpen = true;
    }

    
}
