using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenDark : MonoBehaviour
{
    public Material mat;
    public static FullScreenDark _instance;
    public static FullScreenDark instance{
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<FullScreenDark>();
            }
            return _instance;
        }
    }
    public float darkIntense;
    public float maxDarkIntense;
    private GameConfig_SO gameConfig_SO;

    void Awake()
    {
        //mat = GetComponent<Material>();
        darkIntense = 0;
        gameConfig_SO = GameConfigManager.instance.gameConfig_SO;
        if (gameConfig_SO == null)
        {
            Debug.LogError("GameConfig_SO not found");
        }
        maxDarkIntense = gameConfig_SO.maxDark;
    }
    private void OnEnable()
    {
        CharacterEventManager.instance.characterEvent_SO._OnInDarkVFX += NonLighting;
        CharacterEventManager.instance.characterEvent_SO._OnOutDarkVFX += Lighting;
    }

    void FixedUpdate()
    {
        mat.SetFloat("_DarkIntense", darkIntense);
    }
    
    public  void Lighting()
    {
        if (darkIntense > 0)
        {
            float speed = Mathf.Lerp(gameConfig_SO.darkSpeed,gameConfig_SO.darkSpeed*10, darkIntense / maxDarkIntense);
            darkIntense -= speed * Time.deltaTime;
        }
       
    }

    public  void NonLighting()
    {

        float speed = Mathf.Lerp(gameConfig_SO.darkSpeed,gameConfig_SO.darkSpeed*10, darkIntense / maxDarkIntense);
        darkIntense += speed * Time.deltaTime;
    }
}
