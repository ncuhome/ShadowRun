using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIEventController : MonoBehaviour
{
    public void RestartNovice()
    {
        LoadManager.LoadingScene(SceneEnum.Novice);
    }
    public void StartGame()
    {
        LoadManager.LoadingScene(SceneEnum.Game);
    }
}
