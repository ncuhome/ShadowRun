using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Transform begin;
    public Transform end;

    private void Awake()
    {
        if (!begin) begin = transform.Find("Begin");
        if (!end) end = transform.Find("End");
    }
}
