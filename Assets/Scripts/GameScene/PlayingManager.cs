using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour
{
    public GameConfig_SO gameConfig_SO;
    private bool isDead = false;
    private void Awake()
    {
        gameConfig_SO.hp = gameConfig_SO.maxDark;
    }
    void Update()
    {
        UpdateLightState(LightDetect.totalIntensity);

    }

    private void UpdateLightState(float lightIntense)
    {
        if (lightIntense >= gameConfig_SO.minLight)
        {
            CharacterEventManager.instance._OnOutDark.Invoke();
        }

        else 
        {
            CharacterEventManager.instance._OnInDark.Invoke();
            if(FullScreenDark.instanse.darkIntense>=gameConfig_SO.maxDark && !isDead)
            {
                isDead = true;
                CharacterEventManager.instance._OnDead.Invoke();
            }
                
        }        
    }
}
