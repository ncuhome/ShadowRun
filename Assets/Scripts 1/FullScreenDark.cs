using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenDark : MonoBehaviour
{
    public Material mat;
    public static FullScreenDark instanse;
    public float darkIntense;
    public float darkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //mat = GetComponent<Material>();
        darkIntense = 0;
        instanse = this;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_DarkIntense", darkIntense);
    }

    public  void Lighting()
    {
        if (darkIntense > 0)
        {
            darkIntense -= darkSpeed * Time.deltaTime;
        }
       
    }

    public  void NonLighting()
    {

        darkIntense += darkSpeed * Time.deltaTime;

    }
}
