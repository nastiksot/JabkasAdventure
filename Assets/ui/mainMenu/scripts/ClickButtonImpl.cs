using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonImpl : BaseMono, ClickButton
{
  private Action onClickListener;
  private void Start()
  {
    gameObject.GetComponentInChildren<Button>().onClick.AddListener(() =>
    {
      onClickListener.Invoke();
    });
  }

  public void setOnClickListener(Action onClickListener)
  {
    this.onClickListener = onClickListener;
  }
}
