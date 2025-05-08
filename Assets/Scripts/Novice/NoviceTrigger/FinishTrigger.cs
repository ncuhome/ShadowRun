using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject finishPanel;
    private GameObject player;
    private bool isTriggered = false;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("find no player");
            return;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isTriggered)
        {
            Time.timeScale = 0;
            isTriggered = true;
            finishPanel.SetActive(true);
            PlayerPrefs.SetInt("Noviced", 1);
        }
    }
}
