using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEvent_SO", menuName = "Event/GameEvent_SO")]
public class GameEvent_SO : ScriptableObject
{
    public UnityAction _OnPlayEnterSceneMusic;
    public UnityAction _OnEnteringGame;
    public UnityAction _OnExitGame;


    public void OnPlayEnterSceneMusic()
    {
        _OnPlayEnterSceneMusic?.Invoke();
    }
    public void OnEnteringGame()
    {
        _OnEnteringGame?.Invoke();
    }
    public void OnExitGame()
    {
        _OnExitGame?.Invoke();
    }
  
}