using System;
using System.Collections;
using UnityEngine;
using Utility;

namespace Disablers
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasDisabler : BaseObjectDisabler
    {
        [SerializeField] private CanvasGroup canvasGroup;

        private Action<float> onAlphaChange;
        private Action<bool> onInteractableChange;

        public CanvasGroup CanvasGroup => canvasGroup;
        public event Action<bool> OnInteractableChange
        {
            add => onInteractableChange += value;
            remove => onInteractableChange -= value;
        }
        public event Action<float> OnAlphaChange
        {
            add => onAlphaChange += value;
            remove => onAlphaChange -= value;
        }

        public float Alpha
        {
            get => canvasGroup.alpha;
        }

        public bool Interactable
        {
            get => canvasGroup.interactable;
        }

        private void OnValidate()
        {
            canvasGroup = gameObject.GetComponent<CanvasGroup>();
        }

        public override void DisplayObject(bool state)
        {
            CanvasTool.State(ref canvasGroup, state);
            onAlphaChange?.Invoke(canvasGroup.alpha);
            onInteractableChange?.Invoke(state);
        }

        public override IEnumerator DisplayObject(bool isVisible, float delay, Action<BaseObjectDisabler> action = null)
        {
            onAlphaChange?.Invoke(isVisible ? 1 : 0);
            onInteractableChange?.Invoke(isVisible);
            yield return CanvasTool.State(canvasGroup, isVisible, delay, group => action?.Invoke(this));
        }
    }
}