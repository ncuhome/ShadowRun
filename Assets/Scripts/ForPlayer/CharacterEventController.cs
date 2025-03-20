using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEventController : MonoBehaviour
{
    public CharacterEvent_SO characterEvent_SO;
    public UnityEvent _OnPickEquip;
    public UnityEvent _OnDeading;
    public UnityEvent _OnUseEquipment;

    private void OnEnable()
    {
        characterEvent_SO._OnPlayPickEquipMusic += OnPlayPickEquipMusic;
        characterEvent_SO._OnPlayUseEquipMusic += OnPlayUseEquipMusic;
        characterEvent_SO._OnDeadingVFX += OnDeadingVFX;
        characterEvent_SO._OnPlayDeadingAnim += OnPlayDeadingAnim;
    }
    private void OnDisable()
    {
        characterEvent_SO._OnPlayPickEquipMusic -= OnPlayPickEquipMusic;
        characterEvent_SO._OnPlayUseEquipMusic -= OnPlayUseEquipMusic;
        characterEvent_SO._OnDeadingVFX -= OnDeadingVFX;
        characterEvent_SO._OnPlayDeadingAnim -= OnPlayDeadingAnim;
    }

    public void OnPlayPickEquipMusic()
    {
 
    }
    public void OnPlayUseEquipMusic()
    {
        
    }
    public void OnDeadingVFX()
    {
        
    }
    public void OnPlayDeadingAnim()
    {
        
    }
}