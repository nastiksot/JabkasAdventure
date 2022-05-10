using System;
using System.Collections;
using UnityEngine;

namespace Disablers
{
    public class GameObjectDisabler : BaseObjectDisabler
    {
        public override void DisplayObject(bool state)
        {
            gameObject.SetActive(state);
        }

        public override IEnumerator DisplayObject(bool isVisible, float delay, Action<BaseObjectDisabler> action = null)
        {
            DisplayObject(isVisible);
            yield return new WaitForSeconds(delay);
            action?.Invoke(this);
        }
    }
}