using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BaseMono
{
    [SerializeField] CanvasGroup panel;
    [SerializeField] Button submitButton;
    private static bool isOpen = false;

    private void Start()
    {
        submitButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        panel.alpha = 0;
        Time.timeScale = 1f;
        isOpen = false;
    }

    public void OpenPanel()
    {
        panel.alpha = 1;
        Time.timeScale = 0f;
        isOpen = true;
    }
}