using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                if (!(_assetsManager = Resources.Load("UI/AssetsManager") as AssetsManager))
                    Debug.LogError("no asset Manager in path");
            }
            return _assetsManager;
        }
    }
    [Header("装备栏预制体")]
    public GameObject equipTab;

}
