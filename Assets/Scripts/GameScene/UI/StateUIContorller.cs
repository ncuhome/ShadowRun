using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateUIContorller : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Slider hpSlider;
    public GameConfig_SO gameConfig_SO;
 
    private void OnEnable()
    {
        CharacterEventManager.instance.characterEvent_SO._OnInDarkUI += SetNonLightState;
        CharacterEventManager.instance.characterEvent_SO._OnOutDarkUI += SetLightingState;
    }
    private void OnDisable()
    {
        CharacterEventManager.instance.characterEvent_SO._OnInDarkUI -= SetNonLightState;
        CharacterEventManager.instance.characterEvent_SO._OnOutDarkUI -= SetLightingState;
    }

    private void SetHpUI()
    {
        hpSlider.value = gameConfig_SO.hp / gameConfig_SO.maxDark;
    }
    private void SetState(string s)
    {
        healthText.text = s;
    }
    private void SetLightingState()
    {
        SetState("state:lighting");
        if(gameConfig_SO.hp<gameConfig_SO.maxDark)
            gameConfig_SO.hp += gameConfig_SO.darkSpeed * Time.fixedDeltaTime;
        SetHpUI();
    }
    private void SetNonLightState()
    {
        SetState("state:nonlight");
        if (gameConfig_SO.hp > 0)
            gameConfig_SO.hp -= gameConfig_SO.darkSpeed * Time.fixedDeltaTime;
        SetHpUI();
    }

}