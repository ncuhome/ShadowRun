using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Map : MonoBehaviour
{
    public Transform begin;
    public Transform end;
    public Light2D[] lights;  

    private void Awake()
    {
        if (!begin) begin = transform.Find("Begin");
        if (!end) end = transform.Find("End");
        if (lights == null || lights.Length==0) lights = transform.GetComponentsInChildren<Light2D>();
        if (lights == null || lights.Length == 0) Debug.Log("no lights on current map");
    }
}
