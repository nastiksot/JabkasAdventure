using System;
using System.Collections;

public interface NewsStand
{
    IEnumerator HideBubble();
    void onStandCollited(Action newsStandCollited);
}