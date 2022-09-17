using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDim : MonoBehaviour
{
    public static float dim;
    UnityEngine.Rendering.Universal.Light2D light;

    private void Start()
    {
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }
    private void Update()
    {
        light.intensity = dim;
    }
}