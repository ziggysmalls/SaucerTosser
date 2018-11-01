using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacegate : MonoBehaviour {
    public GameObject triggerZone;
    public SpacegateLight[] lights;

    bool isTriggered = false;

    public void triggerSpacegate()
    {
        isTriggered = true;
        foreach (SpacegateLight light in lights) light.Trigger();
    }
}
