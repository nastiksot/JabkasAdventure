using System;
using System.Collections;
using UnityEngine;

namespace Disablers
{
    public abstract class BaseObjectDisabler : MonoBehaviour
    {
        public abstract void DisplayObject(bool state);

        public abstract IEnumerator DisplayObject(bool isVisible, float delay, Action<BaseObjectDisabler> action = null);
    }
}