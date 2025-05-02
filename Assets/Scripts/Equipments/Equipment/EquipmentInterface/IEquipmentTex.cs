using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����װ����ͼ�Ľӿڣ�Ҫ��ÿ��װ����ʰ��֮ǰ���������Ԥ������Ϣ
/// </summary>
public interface IEquipmentTex 
{
    public EquipmentInfoStruct infoStruct { get;}

}

/// <summary>
/// ���ڴ��װ��Ԥ�������Ϣ
/// </summary>
public struct EquipmentInfoStruct
{
    public GameObject equipmentPreb;
    public int equipmentID;
    
}
