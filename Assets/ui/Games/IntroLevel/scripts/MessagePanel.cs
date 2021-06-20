using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BaseMono
{
    [SerializeField] GameObject panel;
    [SerializeField] Button submitButton;
    private static bool isOpen = false;

    private void Start()
    {
        submitButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        panel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isOpen = false;
    }

    public void OpenPanel()
    {
        panel.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isOpen = true;
    }
}