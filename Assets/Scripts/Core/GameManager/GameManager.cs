using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameEvent_SO gameEvent_SO;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
