using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AttributeMinMaxRange : PropertyAttribute
{
    public AttributeMinMaxRange(float min, float max)
    {
        Min = min;
        Max = max;
    }

    public float Min { get; private set; }
    public float Max { get; private set; }
}

[Serializable]
public struct RangedFloat
{
    public float minValue;
    public float maxValue;
}