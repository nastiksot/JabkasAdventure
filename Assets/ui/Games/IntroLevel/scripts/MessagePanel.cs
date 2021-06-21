using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BaseMono
{
    [SerializeField] private GameObject panel; 
    [SerializeField] private bool isOpen = false;

    
    public void ClosePanel()
    {
        panel.gameObject.SetActive(isOpen);
        Time.timeScale = 1f;
        isOpen = !isOpen;
    }

    public void OpenPanel()
    {
        panel.gameObject.SetActive(isOpen);
        Time.timeScale = 0f;
        isOpen = !isOpen;
    }
}