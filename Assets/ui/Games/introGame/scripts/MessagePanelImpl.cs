using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanelImpl : BaseMono, MessagePanel
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject submitButton;
    private static bool isOpen = false;

    private void Start()
    {
        submitButton.GetComponent<Button>().onClick.AddListener(ClosePanel);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        isOpen = false;
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        isOpen = true;
    }
}