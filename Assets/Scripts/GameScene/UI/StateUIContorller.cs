using System.Collections;
using TMPro;
using UnityEngine;

public class StateUIContorller : MonoBehaviour
{
    public TextMeshProUGUI healthText;
   
    public static StateUIContorller _instance;
    public static StateUIContorller instance {
        get
        {
            if (!_instance)
            {
                if(!(_instance = FindAnyObjectByType<StateUIContorller>()))
                {
                    Debug.LogError("no stateUIController in the scene!");
                }
            }
            return _instance;
        } 
    }

    public void SetState(string s)
    {
        healthText.text = s;
    }

    
}