using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] StreetLight1[] streetlights;

    public void SwitchLights()
    {
        foreach (StreetLight1 light in streetlights)
        {
            light.ToggleLight();
        }
    }
}
