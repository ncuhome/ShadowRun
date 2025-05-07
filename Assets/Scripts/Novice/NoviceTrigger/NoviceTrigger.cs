using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NoviceTrigger : MonoBehaviour
{
    private Image[] tips;
    private bool isTriggered = false;
    void Awake()
    {
        tips = GetComponentsInChildren<Image>(true);
        if (tips == null)
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
            isTriggered = true;
            StartCoroutine(ShowTips());          
        }
    }
 
    private IEnumerator ShowTips()
    {
        int i = 0;
        GameObject tip;
        while(i<tips.Length)
        {
            tip = tips[i].gameObject;
            tip.SetActive(true);
             #if UNITY_ANDROID || UNITY_IOS
                if (Input.touchCount > 0&& Input.GetTouch(0).phase==UnityEngine.TouchPhase.Began) 
                {
                    tip.SetActive(false);
                    i++;                   
                }            
            #else
                if (Keyboard.current.anyKey.isPressed)
                {
                    tips.gameObject.SetActive(false);                                
                    i++;
                }
            #endif
            yield return null;
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
