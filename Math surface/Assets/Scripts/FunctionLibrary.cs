using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public static float Wave(float x, float t)
    {
        return Sin(PI * (x + t));
    }
    public static float MultiWave(float x, float t)
    {
        float y = Sin(PI * (x + t * 0.5f));
        y += Sin(2 * PI * (x + t)) * 0.5f;
        return y * (2f / 3f);
    }
    public static float Ripple(float x, float t)
    {
        float d = Abs(x);
        float y = Sin(PI * (4f * d - t));
        return y / (1 + 10*d);
    }
}
