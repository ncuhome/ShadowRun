using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SceneEvent_SO", menuName = "Event/SceneEvent_SO")]
public class SceneEvent_SO : ScriptableObject
{
    public UnityAction _RestartGame;
    public UnityAction _BackToSart;

    public void BackToSart()
    {
        _BackToSart?.Invoke();
    }
    public void RestartGame()
    {
        _RestartGame?.Invoke();
    }
    public void GC()
    {
        _RestartGame = null;
        _BackToSart = null;
    }
}