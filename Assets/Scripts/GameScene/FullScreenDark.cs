using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenDark : MonoBehaviour
{
    public Material mat;
    public static FullScreenDark instanse;
    public float darkIntense;
    public GameConfig_SO gameConfig_SO;
    // Start is called before the first frame update
    void Awake()
    {
        //mat = GetComponent<Material>();
        darkIntense = 0;
        instanse = this;
    }
    private void OnEnable()
    {
        CharacterEventManager.instance.characterEvent_SO._OnInDarkVFX += NonLighting;
        CharacterEventManager.instance.characterEvent_SO._OnOutDarkVFX += Lighting;
    }
    private void OnDisable()
    {
        CharacterEventManager.instance.characterEvent_SO._OnInDarkVFX -= NonLighting;
        CharacterEventManager.instance.characterEvent_SO._OnOutDarkVFX -= Lighting;
    }

    void FixedUpdate()
    {
        mat.SetFloat("_DarkIntense", darkIntense);
    }
    
    public  void Lighting()
    {
        if (darkIntense > 0)
        {
            darkIntense -= gameConfig_SO.darkSpeed * Time.fixedDeltaTime;
        }
       
    }

    public  void NonLighting()
    {

        darkIntense += gameConfig_SO.darkSpeed * Time.fixedDeltaTime;

    }
}
