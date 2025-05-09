using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

public class Map : MonoBehaviour
{
    public Transform begin;
    public Transform end;
    public Light2D[] lights;
    public IEquipmentTex[] equipments;
    public Transform[] equipmentTrans; 
    private EquipmentInfoStruct[] equipmentInfoStructs; 

    private void Awake()
    {
        if (!begin) begin = transform.Find("Begin");
        if (!end) end = transform.Find("End");
        if (lights == null || lights.Length==0) lights = transform.GetComponentsInChildren<Light2D>();
        if (lights == null || lights.Length == 0) Debug.Log("no lights on current map");
        if (equipments == null || equipments.Length == 0) equipments = transform.GetComponentsInChildren<IEquipmentTex>();
        if (equipments == null || equipments.Length == 0) Debug.Log("no equipments on current map");
        equipmentTrans = new Transform[equipments.Length];
        equipmentInfoStructs = new EquipmentInfoStruct[equipments.Length];
        for(int i = 0; i < equipments.Length; i++)
        {
            if (equipments[i] == null) Debug.Log("no equipment on current map");
            equipmentInfoStructs[i] = equipments[i].infoStruct;
            equipmentTrans[i] = equipments[i].equipTransform;
        }
    }
    void OnEnable()
    {
        for(int i = 0;i < equipmentInfoStructs.Length;i++)
        {
            if(equipments[i]==null)
            {
                Instantiate(equipmentInfoStructs[i].equipmentPreb,equipmentTrans[i].position,new Quaternion());
            }
        }
    }
}
