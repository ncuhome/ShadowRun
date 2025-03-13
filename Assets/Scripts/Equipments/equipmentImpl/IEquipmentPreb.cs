using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipmentPerb 
{
    /// <summary>
    /// 使用道具
    /// </summary>
    /// <param name="transform">玩家对象</param>
    /// <returns>返回使用道具的协程</returns>
    IEnumerator Use(Transform transform);
    /// <summary>
    /// 初始化道具
    /// </summary>
    /// <param name="transform">玩家坐标</param>
    void Init(Transform transform);
}
