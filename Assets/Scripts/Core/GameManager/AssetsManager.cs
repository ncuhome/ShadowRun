using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "AssetsManager", menuName = "Asset/AssetsManager")]
public class AssetsManager : ScriptableObject
{
    private static AssetsManager _assetsManager;
    public static AssetsManager instance
    {
        get
        {
            if (!_assetsManager)
            {
                if (!(_assetsManager = Resources.Load("AssetsManager") as AssetsManager))
                    Debug.LogError("no asset Manager in path");
            }
            return _assetsManager;
        }
    }
    [Header("UI-equipTab")]
    public AssetReference equipTab;

    [Space(5)]
    [Header("Game-Equipment-Used")]
    [Space(2)]
    [Header("equip-lighting0")]
    public AssetReference equipLightingPreb;
    [Header("equip-lighting1")]
    public AssetReference equipLightingPreb1;
    [Header("equip-blessing")]
    public AssetReference equipBlessingPreb;
    [Header("equip-Jumping")]
    public AssetReference equipJumpingPreb;

}
