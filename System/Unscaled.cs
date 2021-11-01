using System.Collections;
using UnityEngine;

public static class Unscaled
{
    public static IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.unscaledTime;
        while (Time.unscaledTime < start + time)
        {
            yield return null;
        }
    }
}