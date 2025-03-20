using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterAction_SO", menuName = "Data/CharacterAction_SO")]
public class CharacterAction_SO : ScriptableObject
{
    [Header("角色向前移动速度")]
    public float moveForwardSpeed;
    [Header("角色向后移动速度")]
    public float moveBackSpeed;
    [Header("角色固定移动速度")]
    public float fixSpeed;
    [Header("角色跳跃最大时间")]
    public float jumpMaxTime;
    [Header("角色跳跃力度")]
    public float jumpHeight;
}