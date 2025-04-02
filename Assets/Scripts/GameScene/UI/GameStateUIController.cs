using System.Collections;
using UnityEngine;

public class GameStateUIController : MonoBehaviour
{
    public UIEvent_SO UIEvent;
    public GameObject pausePanel;

    private void OnEnable()
    {
        UIEvent._PauseGame += PauseGame;
        UIEvent._StopPause += StopPause;
        UIEvent._ShowPauseMenu += ShowPauseMenu;
        UIEvent._ClosePauseMenu += ClosePauseMenu;
    }
    private void OnDisable()
    {
        UIEvent._PauseGame -= PauseGame;
        UIEvent._StopPause -= StopPause;
        UIEvent._ShowPauseMenu -= ShowPauseMenu;
        UIEvent._ClosePauseMenu -= ClosePauseMenu;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void StopPause()
    {
        Time.timeScale = 1;
    }
    void ShowPauseMenu()
    {
        pausePanel.SetActive(true);
    }
    void ClosePauseMenu()
    {
        pausePanel.SetActive(false);
    }
}