using System;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Games.mainMenu.scripts
{
    public class ClickButtonImpl : BaseMono
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
}