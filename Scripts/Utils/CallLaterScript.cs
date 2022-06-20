using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class CallLaterScript
{
    public static IEnumerator WaitSeconds(Action callback, int seconds)
    {
        Debug.Log ("WaitSeconds 1");

        int counter = seconds;
        while (counter > 0) {
            Debug.Log ("WaitSeconds 2");
            yield return new WaitForSeconds (1);
            Debug.Log ("WaitSeconds 3");
            counter--;
        }

        Debug.Log ("Callback");
        callback?.Invoke();
    }
}