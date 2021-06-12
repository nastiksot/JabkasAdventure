using System;
using System.Collections;

public interface NewsStand
{
    IEnumerator HideBubble();
    void OnStandCollited(Action newsStandCollited);
}