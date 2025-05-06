using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour
{
    private GameConfig_SO gameConfig_SO;
    private Transform player;
    private bool isDead = false;
    private void Awake()
    {      
        gameConfig_SO = GameConfigManager.instance.gameConfig_SO;
        gameConfig_SO.hp = gameConfig_SO.maxDark;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Time.timeScale = 1;
    }
    void Update()
    {
        UpdateLightState(LightDetect.totalIntensity);
        UpdatePlayerHeightState();
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
            if(FullScreenDark.instance.darkIntense>=gameConfig_SO.maxDark && !isDead)
            {
                isDead = true;
                CharacterEventManager.instance._OnDead.Invoke();
            }
                
        }        
    }
    private void UpdatePlayerHeightState()
    {
        if (player.position.y <= gameConfig_SO.playerHeight)
        {
            CharacterEventManager.instance._OnDead.Invoke();
        }
    }
}
