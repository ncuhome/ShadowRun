using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //BloodUIManager.instanse.Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLightState(LightDetect.instance.totalIntensity);
    }

    private void UpdateLightState(float lightIntense)
    {
        if (lightIntense >= Constants.MIN_LIGHT)
        {
            BloodUIManager.instanse.SetBlood("State:lighting");
            FullScreenDark.instanse.Lighting();
        }

        else 
        {
            //Debug.Log(lightIntense.ToString());
            BloodUIManager.instanse.SetBlood("State:Nonlight");
            FullScreenDark.instanse.NonLighting();
        }

        
    }
}
