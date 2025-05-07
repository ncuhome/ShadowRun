using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NoviceTrigger : MonoBehaviour
{
    private Image tip;
    private bool isTriggered = false;
    void Awake()
    {
        tip = GetComponentInChildren<Image>(true);
        if (tip == null)
        {
            Debug.LogError("find no tip image");
            return;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isTriggered)
        {
            Debug.Log("触发了新手引导");
            Time.timeScale = 0;
            tip.gameObject.SetActive(true);
            isTriggered = true;
        }
    }
    void Update()
    {
        if(isTriggered)
        {
            #if UNITY_ANDROID || UNITY_IOS
                if (Input.touchCount > 0&& Input.GetTouch(0).phase==UnityEngine.TouchPhase.Began) 
                {
                    tip.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    Time.timeScale = 1;
                }
            #endif
            if (Keyboard.current.anyKey.isPressed)
            {
                tip.gameObject.SetActive(false);
                gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
