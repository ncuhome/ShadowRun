using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessing : MonoBehaviour,IEquipmentTex
{
    EquipmentInfoStruct equipmentInfoStruct;
    Transform localTransform;
    public Transform equipTransform
    {
        get
        {
            if(localTransform==null) localTransform = transform;
            return localTransform;
        }
    }
    public GameObject equipPreb;
    public EquipmentInfoStruct infoStruct {
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
