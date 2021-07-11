using UI.Base;
using UnityEngine;

namespace UI.Games.MarioLevel.Switcher
{
    public class SwitchController : BaseMono
    {
        [SerializeField] private bool isOn;

        public bool IsOn
        {
            get => isOn;
            set => isOn = value;
        }

        public static SwitchController instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void FlipSwitch()
        {
            isOn = !isOn;
        }
    }
}