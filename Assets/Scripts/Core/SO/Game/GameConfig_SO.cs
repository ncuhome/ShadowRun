using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig_SO", menuName = "GameConfig/GameConfig_SO")]
public class GameConfig_SO : ScriptableObject
{
    [Header("四周黑暗速度")]
    public float darkSpeed;
    [Header("黑暗追逐加速")]
    public float blackChaseSpeed;
    [Header("最大黑影距离")]
    public float maxBlackDistance;
    [Header("最大的屏幕黑暗数值")]
    public float maxDark;
    [Header("光明状态最低光照浓度")]
    public float minLight;
    [Header("角色hp")]
    public float hp;
    [Header("判断角色死亡的距离")]
    public float deadDistance;
    [Header("角色死亡最小高度")]
    public float playerHeight;
}