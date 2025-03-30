using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [Range(0,1)]
    public float parallax;

    SpriteRenderer render;
    float texSizeUnitX;
    Vector3 lastCameraPos;
    new Camera camera;

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        texSizeUnitX = render.bounds.size.x;
        camera= Camera.main;
        lastCameraPos = camera.transform.position;
    }
    void LateUpdate()
    {
        ParallaxX();
    }

    void ParallaxX()
    {
        float distance = (camera.transform.position - lastCameraPos).x;
        transform.position = new Vector3(transform.position.x + distance * (1 - parallax),
            transform.position.y, 
            transform.position.z);
        //relat distance trans 
        float relaDistance = (camera.transform.position - transform.position).x;
        if (Mathf.Abs(relaDistance) >= texSizeUnitX * 0.5)
        {
            float offest = relaDistance > 0 ? texSizeUnitX / 2 : -texSizeUnitX / 2;
            transform.position += new Vector3(offest, 0, 0);
        }
        lastCameraPos = Camera.main.transform.position;
    }

   

}
