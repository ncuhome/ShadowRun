using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipmentPerb 
{
    /// <summary>
    /// ʹ�õ���
    /// </summary>
    /// <param name="transform">��Ҷ���</param>
    /// <returns>����ʹ�õ��ߵ�Э��</returns>
    IEnumerator Use(Transform transform);
    /// <summary>
    /// ��ʼ������
    /// </summary>
    /// <param name="transform">�������</param>
    void Init(Transform transform);
}
