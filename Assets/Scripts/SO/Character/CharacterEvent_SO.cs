using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CharacterEvent_SO", menuName = "Event/CharacterEvent_SO")]
public class CharacterEvent_SO : ScriptableObject
{
    public UnityAction _OnPlayPickEquipMusic;
    public UnityAction _OnPlayUseEquipMusic;
    public UnityAction _OnDeadingVFX;
    public UnityAction _OnPlayDeadingAnim;

    public void OnPlayPickEquipMusic()
    {
        _OnPlayPickEquipMusic?.Invoke();
    }
    public void OnPlayUseEquipMusic()
    {
        _OnPlayUseEquipMusic?.Invoke();
    }
    public void OnDeadingVFX()
    {
        _OnDeadingVFX?.Invoke();
    }
    public void OnPlayDeadingAnim()
    {
        _OnPlayDeadingAnim?.Invoke();
    }
}