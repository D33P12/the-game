using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight1 : MonoBehaviour
{

    [SerializeField] private GameObject Light;
    public void Start()
    {
        Light.gameObject.SetActive(false);
    }
    public void ToggleLight()
    {
        Light.gameObject.SetActive(!Light.activeSelf);
    }
}
