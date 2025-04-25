using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UIEvent_SO", menuName = "Event/UIEvent_SO")]
public class UIEvent_SO : ScriptableObject
{
    public UnityAction _PauseGame;
    public UnityAction _StopPause;
    public UnityAction _ShowPauseMenu;
    public UnityAction _ClosePauseMenu;
    public UnityAction _ShowDeathMenu;
    public UnityAction _CloseDeathMenu;

    public void PauseGame()
    {
        _PauseGame?.Invoke();
    }
    public void StopPause()
    {
        _StopPause?.Invoke();
    }
    public void ShowPauseMenu()
    {
        _ShowPauseMenu?.Invoke();
    }
    public void ClosePauseMenu()
    {
        _ClosePauseMenu?.Invoke();
    }
    public void ShowDeathMenu()
    {
        _ShowDeathMenu?.Invoke();
    }
    public void CloseDeathMenu()
    {
        _CloseDeathMenu?.Invoke();
    }
    public void GC()
    {
        _PauseGame = null;
        _StopPause = null;
        _ShowPauseMenu = null;
        _ClosePauseMenu = null;
        _ShowDeathMenu = null;
        _CloseDeathMenu = null;
    }
}