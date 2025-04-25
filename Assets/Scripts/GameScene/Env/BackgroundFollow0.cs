using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow0 : MonoBehaviour
{
    [Range(0,1)]
    public float parallax;
    [Header("左背景")]
    public GameObject leftBg;
    [Header("右背景")]
    public GameObject rightBg;
    [Header("y轴偏移量")]
    public float y_Offest ;

    SpriteRenderer render;
    float texSizeUnitX;
    Vector3 lastCameraPos;
    new Camera camera;
    float maxDistance;
    float minDistance;
    void Start()
    {
        render = leftBg.GetComponent<SpriteRenderer>();
        texSizeUnitX = render.bounds.size.x;
        camera= Camera.main;
        lastCameraPos = camera.transform.position;
        maxDistance = (camera.orthographicSize * 2 * camera.aspect - texSizeUnitX) / 2 + texSizeUnitX;
        minDistance = -(camera.orthographicSize * 2 * camera.aspect - texSizeUnitX) / 2 ;
    }
    void LateUpdate()
    {
        ParallaxX();
    }

    void ParallaxX()
    {
        float distance = (camera.transform.position - lastCameraPos).x;
        transform.position = new Vector3(transform.position.x + distance * (1 - parallax),
            camera.transform.position.y + y_Offest, 
            transform.position.z);
        //relat distance trans 
        float relaDistance = (camera.transform.position - leftBg.transform.position).x;
        
        if (relaDistance >= maxDistance)
        {
            leftBg.transform.position += new Vector3(2*texSizeUnitX, 0, 0);
            ExchangePos();
        }
        else if (relaDistance <= minDistance)
        {
            rightBg.transform.position -= new Vector3(2*texSizeUnitX, 0, 0);
            ExchangePos();
        }
        lastCameraPos = Camera.main.transform.position;
    }

   void ExchangePos()
    {
        GameObject t = leftBg;
        leftBg = rightBg;
        rightBg = t;
    }

}
