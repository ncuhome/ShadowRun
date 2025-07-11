﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEventManager : MonoBehaviour
{
    public CharacterEvent_SO characterEvent_SO;
    public UnityEvent _OnDead;
    public UnityEvent _OnPickEquip;
    public UnityEvent _OnUseEquipment;
    public UnityEvent _OnInDark;
    public UnityEvent _OnOutDark;
    private static CharacterEventManager _instance;
    public static CharacterEventManager instance{
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CharacterEventManager>();             
            }
            return _instance;
        }
    }
   
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
        characterEvent_SO.GC();
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