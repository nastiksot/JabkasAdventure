using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonImpl : BaseMono, ClickButton
{
    [SerializeField] private Button clickButton;
    private Action onClickListener;

    private void Start()
    {
        clickButton.onClick.AddListener(() => { onClickListener.Invoke(); });
    }

    public void setOnClickListener(Action onClickListener)
    {
        this.onClickListener = onClickListener;
    }
}