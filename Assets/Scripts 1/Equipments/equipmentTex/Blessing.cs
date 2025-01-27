using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessing : MonoBehaviour,IEquipment
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
            prebPath = Constants.EQUIPMENT_BLESS_PREB_PATH
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
