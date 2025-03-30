using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour,IEquipmentTex
{
    EquipmentInfoStruct equipmentInfoStruct;
    public GameObject equipPreb;
    public EquipmentInfoStruct infoStruct
    {
        get
        {
            if (!equipPreb) Debug.LogError("no equipment preb on the " + gameObject.name);
            SetStruct();
            return equipmentInfoStruct;
        }
    }

    public void SetStruct()
    {
        equipmentInfoStruct = new EquipmentInfoStruct
        {
            equipmentPreb = equipPreb
        };
    }
}
