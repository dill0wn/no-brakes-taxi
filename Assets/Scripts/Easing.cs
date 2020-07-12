using System;

public class Easing
{
    public static float RangeMap(float val, Func<float, float> ease = null)
    {
        if (ease == null)
        {
            ease = Easing.Linear;
        }

        return RangeMap(val, 0f, 1f, 0f, 1f, ease);
    }

    public static float RangeMap(float val, float outMin = 0f, float outMax = 1f, Func<float, float> ease = null)
    {
        if (ease == null)
        {
            ease = Easing.Linear;
        }
        return RangeMap(val, 0f, 1f, outMin, outMax, ease);
    }

    public static float RangeMap(float val, float inMin = 0f, float inMax = 1f,
                                float outMin = 0f, float outMax = 1f, Func<float, float> ease = null)
    {
        if (ease == null)
        {
            ease = Easing.Linear;
        }

        float inRange = inMax - inMin;
        float t = (val - inMin) / inRange;

        t = ease(t);

        return outMin + (outMax - outMin) * t;
    }

    public static float Flip(float t)
    {
        return 1 - t;
    }

    public static float Linear(float t)
    {
        return t;
    }

    public static float SmoothStart2(float t)
    {
        return t * t;
    }

    public static float SmoothStart3(float t)
    {
        return t * t * t;
    }

    public static float SmoothStart4(float t)
    {
        return t * t * t * t;
    }

    public static float SmoothStop2(float t)
    {
        return Flip(SmoothStart2(Flip(t)));
    }

    public static float SmoothStop3(float t)
    {
        return Flip(SmoothStart3(Flip(t)));
    }

    public static float SmoothStop4(float t)
    {
        return Flip(SmoothStart4(Flip(t)));
    }
}
