using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateUIController : MonoBehaviour
{
    public UIEvent_SO UIEvent;
    public GameObject pausePanel;
    public GameObject deathPanel;

    private void OnEnable()
    {
        UIEvent._PauseGame += PauseGame;
        UIEvent._StopPause += StopPause;
        UIEvent._ShowPauseMenu += ShowPauseMenu;
        UIEvent._ClosePauseMenu += ClosePauseMenu;
        UIEvent._ShowDeathMenu += ShowDeathMenu;
    }
    private void OnDisable()
    {
        UIEvent._PauseGame -= PauseGame;
        UIEvent._StopPause -= StopPause;
        UIEvent._ShowPauseMenu -= ShowPauseMenu;
        UIEvent._ClosePauseMenu -= ClosePauseMenu;
        UIEvent._ShowDeathMenu += ShowDeathMenu;
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
    void ShowDeathMenu()
    {
        deathPanel.SetActive(true);
    }
    void CloseDeathPanel()
    {
        deathPanel.SetActive(false);
    }
}