using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public SceneEvent_SO sceneEvent_SO;
    
    private void OnEnable()
    {
        sceneEvent_SO._BackToSart += OnBackToStart;
        sceneEvent_SO._RestartGame += OnRestartGame;
    }
    private void OnDisable()
    {
        sceneEvent_SO._BackToSart -= OnBackToStart;
        sceneEvent_SO._RestartGame -= OnRestartGame;
        sceneEvent_SO.GC();
    }
    private void OnRestartGame()
    {
        LoadManager.LoadingScene("Game");
    }
    private void OnBackToStart()
    {
        LoadManager.LoadingScene("Start");
    }
}