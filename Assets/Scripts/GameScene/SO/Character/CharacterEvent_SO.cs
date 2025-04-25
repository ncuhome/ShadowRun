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
    public UnityAction _OnInDarkVFX;
    public UnityAction _OnOutDarkVFX;
    public UnityAction _OnInDarkUI;
    public UnityAction _OnOutDarkUI;

    public void OnInDarkVFX()
    {
        _OnInDarkVFX?.Invoke();
    }
    public void OnOutDarkVFX()
    {
        _OnOutDarkVFX?.Invoke();
    }
    public void OnInDarkUI()
    {
        _OnInDarkUI?.Invoke();
    }
    public void OnOutDarkUI()
    {
        _OnOutDarkUI?.Invoke();
    }

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
    /// <summary>
    /// 清理事件
    /// </summary>
    public void GC()
    {
        _OnPlayPickEquipMusic = null;
        _OnPlayUseEquipMusic = null;
        _OnDeadingVFX = null;
        _OnPlayDeadingAnim = null;
        _OnInDarkVFX = null;
        _OnOutDarkVFX = null;
        _OnInDarkUI = null;
        _OnOutDarkUI = null;
    }
}