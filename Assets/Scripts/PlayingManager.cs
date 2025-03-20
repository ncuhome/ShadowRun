using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour
{
    void Update()
    {
        UpdateLightState(LightDetect.totalIntensity);
    }

    private void UpdateLightState(float lightIntense)
    {
        if (lightIntense >= Constants.MIN_LIGHT)
        {
            StateUIContorller.instance.SetState("State:lighting");
            FullScreenDark.instanse.Lighting();
        }

        else 
        {
            //Debug.Log(lightIntense.ToString());
            StateUIContorller.instance.SetState("State:Nonlight");
            FullScreenDark.instanse.NonLighting();
        }

        
    }
}
