using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 所有装备贴图的接口，要求每个装备被拾起之前都必须带有预制体信息
/// </summary>
public interface IEquipment 
{

    EquipmentInfoStruct GetStruct();
    void SetStruct();


}

/// <summary>
/// 用于存放装备预制体的信息
/// </summary>
public struct EquipmentInfoStruct
{
    
    public string prebPath;

  
}
