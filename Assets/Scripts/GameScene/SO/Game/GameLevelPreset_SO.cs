using UnityEngine;

[CreateAssetMenu(fileName = "GameLevelPreset_SO", menuName = "GameConfig/GameLevelPreset_SO")]
public class GameLevelPreset_SO : ScriptableObject
{
    [System.Serializable]
    public class LevelData
    {
        public int trigglerScore;
        public string levelName;
        public float darkSpeed;
        public float minLight;
        public float deadDistance;
        public float moveForwardSpeed;
        public float moveBackSpeed;
        public float fixSpeed;
        public float jumpMaxTime;
        public float jumpHeight;
    }
    [Header("默认关卡数据")]   
    [SerializeField]
    public LevelData defualtLevelData;
    [Header("预设关卡数据")]
    [SerializeField]
    public LevelData[] levelDatas;

}