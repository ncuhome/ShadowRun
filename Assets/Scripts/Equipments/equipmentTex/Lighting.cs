using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour,IEquipment
{
    EquipmentInfoStruct equipmentInfoStruct;
    public EquipmentInfoStruct GetStruct()
    {
        SetStruct();
        return equipmentInfoStruct;
    }

    public void SetStruct()
    {
        equipmentInfoStruct = new EquipmentInfoStruct
        {
            prebPath = Constants.EQUIPENT_LIGHTING_PREB_PATH
        };
    }

    void Start()
    {
        
    }

  


}
